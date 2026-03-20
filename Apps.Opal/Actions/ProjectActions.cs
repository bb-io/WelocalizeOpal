using Apps.Opal.Models.Entities;
using Apps.Opal.Models.Identifier;
using Apps.Opal.Models.Request.Project;
using Apps.Opal.Models.Response.Project;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;

namespace Apps.Opal.Actions;

[ActionList("Projects")]
public class ProjectActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) 
    : OpalInvocable(invocationContext)
{
    [Action("Get project details", Description = "Get information about an existing project")]
    public async Task<GetProjectDetailsResponse> GetProjectDetails([ActionParameter] ProjectIdentifier projectInput)
    {
        var request = new RestRequest($"projects/{projectInput.ProjectId}");
        var response = await Client.ExecuteWithErrorHandling<ProjectEntity>(request);
        return new(response);
    }

    [Action("Create project", Description = "Create a new project")]
    public async Task<BaseProjectResponse> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var body = new
        {
            orchestrator_project_id = input.OrchestratorProjectId,
            callback_url = "https://123.com/",
        };
        var request = new RestRequest("projects", Method.Post).WithJsonBody(body);

        var response = await Client.ExecuteWithErrorHandling<ProjectEntity>(request);
        return new(response);
    }

    [Action("Upload file to project", Description = "Upload file to a project")]
    public async Task<UploadProjectFileResponse> UploadProjectFile(
        [ActionParameter] ProjectIdentifier projectInput,
        [ActionParameter] UploadProjectFileRequest uploadRequest)
    {
        var fileStream = await fileManagementClient.DownloadAsync(uploadRequest.File);
        using var ms = new MemoryStream();
        await fileStream.CopyToAsync(ms);
        var fileBytes = ms.ToArray();

        string fileName = uploadRequest.File.Name;

        var body = new
        {
            name = fileName,
            type = "input",
            source_locale = uploadRequest.SourceLocale,
            target_locale = uploadRequest.TargetLocale,
            content = Convert.ToBase64String(fileBytes)
        };

        var request = new RestRequest($"projects/{projectInput.ProjectId}/files", Method.Post).AddJsonBody(body);
        var response = await Client.ExecuteWithErrorHandling<UploadProjectFileResponse>(request);

        var uploadToS3Client = new RestClient();
        var uploadToS3Request = new RestRequest(response.UploadUrl, Method.Put)
            .AddParameter("application/octet-stream", fileBytes, ParameterType.RequestBody);

        var uploadToS3Response = await uploadToS3Client.ExecuteAsync(uploadToS3Request);
        if (!uploadToS3Response.IsSuccessStatusCode)
            throw new PluginApplicationException($"S3 Upload error. {uploadToS3Response.ErrorMessage}");

        return response;
    }

    [Action("Start project", Description = "Start a project")]
    public async Task StartProject([ActionParameter] ProjectIdentifier projectInput)
    {
        var request = new RestRequest($"projects/{projectInput.ProjectId}/start", Method.Post);
        await Client.ExecuteWithErrorHandling(request);
    }

    [Action("Cancel project", Description = "Cancel a project")]
    public async Task CancelProject([ActionParameter] ProjectIdentifier projectInput)
    {
        var request = new RestRequest($"projects/{projectInput.ProjectId}/cancel", Method.Post);
        await Client.ExecuteWithErrorHandling(request);
    }

    [Action("Complete project", Description = "Complete a project")]
    public async Task CompleteProject(
        [ActionParameter] ProjectIdentifier projectInput,
        [ActionParameter] CompleteProjectRequest completeInput)
    {
        var completeRequest = new RestRequest($"projects/{projectInput.ProjectId}/complete", Method.Post);
        var completeResponse = await Client.ExecuteWithErrorHandling<List<FileEntity>>(completeRequest);

        var s3Client = new RestClient();

        var uploadTasks = completeInput.Files.Select(async userFile =>
        {
            var finalizedFile = completeResponse.FirstOrDefault(f => f.FileName == userFile.Name && f.FileType == "final") ??
                throw new PluginApplicationException($"File with the name of '{userFile.Name}' was not finalized");

            using var fileStream = await fileManagementClient.DownloadAsync(userFile);
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            var uploadToS3Request = new RestRequest(finalizedFile.UploadUrl, Method.Put)
                .AddParameter("application/octet-stream", fileBytes, ParameterType.RequestBody);

            var uploadToS3Response = await s3Client.ExecuteAsync(uploadToS3Request);

            if (!uploadToS3Response.IsSuccessStatusCode)
            {
                throw new PluginApplicationException(
                    $"Failed to upload {userFile.Name} to S3. Error: {uploadToS3Response.ErrorMessage}");
            }
        });

        await Task.WhenAll(uploadTasks);
    }

    [Action("Download project file", Description = "Download a processed project file")]
    public async Task<DownloadFileResponse> DownloadProjectFile(
        [ActionParameter] ProjectIdentifier projectInput,
        [ActionParameter] ProjectFileIdentifier fileInput)
    {
        var project = await GetProjectDetails(projectInput);
        var completedFile = project.Files.First(x => x.FileId == fileInput.ProjectFileId);

        var downloadS3Client = new RestClient();
        var downloadS3Request = new RestRequest(completedFile.DownloadUrl);
        var responseStream = await downloadS3Client.DownloadStreamAsync(downloadS3Request) ??
            throw new PluginApplicationException("Failed to download file from S3. The download stream was null");

        var file = await fileManagementClient.UploadAsync(responseStream, "application/octet-stream", completedFile.FileName);
        return new(file);
    }
}