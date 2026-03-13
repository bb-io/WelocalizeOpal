using RestSharp;
using Apps.Opal.Models.Entities;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Apps.Opal.Models.Identifier;
using Apps.Opal.Models.Request.Project;
using Apps.Opal.Models.Response.Project;

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
    public async Task<CreateProjectResponse> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var body = new
        {
            orchestrator_project_id = input.OrchestratorProjectId,
            content_group_id = input.ContentGroupId,
            callback_url = "https://bridge.blackbird.io/api/AuthorizationCode",
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
        };

        var request = new RestRequest($"projects/{projectInput.ProjectId}/files", Method.Post)
            .WithJsonBody(body)
            .AddFile(fileName, fileBytes, fileName);

        return await Client.ExecuteWithErrorHandling<UploadProjectFileResponse>(request);
    }

    [Action("Start project", Description = "Start a project after all of the files have been uploaded")]
    public async Task StartProject([ActionParameter] ProjectIdentifier projectInput)
    {
        var request = new RestRequest($"projects/{projectInput.ProjectId}/start", Method.Post);
        await Client.ExecuteWithErrorHandling(request);
    }

    [Action("Cancel project", Description = "Cancel a project")]
    public async Task CancelProject([ActionParameter] ProjectIdentifier projectInput)
    {
        var request = new RestRequest($"projects/{projectInput.ProjectId}/cancel", Method.Put);
        await Client.ExecuteWithErrorHandling(request);
    }
}