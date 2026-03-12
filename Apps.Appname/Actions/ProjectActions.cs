using RestSharp;
using Apps.Opal.Models.Request;
using Apps.Opal.Models.Response;
using Apps.Opal.Models.Entities;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.Opal.Actions;

[ActionList("Projects")]
public class ProjectActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) 
    : OpalInvocable(invocationContext)
{
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
}