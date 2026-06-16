using Apps.Opal.Models.Entities;
using Apps.Opal.Models.Identifier;
using Apps.Opal.Models.Response.Project;
using Apps.Opal.Polling.Memories;
using Apps.Opal.Polling.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;

namespace Apps.Opal.Polling;

[PollingEventList("Projects")]
public class ProjectPollingList(InvocationContext invocationContext) : OpalInvocable(invocationContext)
{
    [PollingEvent("On project status changed", Description = "Triggers when the status of a specified project changes")]
    public async Task<PollingEventResponse<ProjectStatusMemory, GetProjectDetailsResponse>> OnProjectStatusChanged(
        PollingEventRequest<ProjectStatusMemory> pollingRequest,
        [PollingEventParameter] ProjectIdentifier project,
        [PollingEventParameter] OnProjectStatusChangedRequest input)
    {
        var request = new RestRequest($"projects/{project.ProjectId}");
        var response = await Client.ExecuteWithErrorHandling<ProjectEntity>(request);
        string currentStatus = response.Status;

        if (pollingRequest.Memory is null || pollingRequest.Memory.LastStatus is null)
        {
            return new PollingEventResponse<ProjectStatusMemory, GetProjectDetailsResponse>
            {
                FlyBird = false,
                Memory = new ProjectStatusMemory { LastStatus = currentStatus },
                Result = null
            };
        }

        if (!string.IsNullOrEmpty(input.ProjectStatus))
        {
            if (input.ProjectStatus.Equals(currentStatus, StringComparison.OrdinalIgnoreCase))
            {
                return new PollingEventResponse<ProjectStatusMemory, GetProjectDetailsResponse>
                {
                    FlyBird = true,
                    Memory = new ProjectStatusMemory { LastStatus = currentStatus },
                    Result = new(response)
                };
            }
            return new PollingEventResponse<ProjectStatusMemory, GetProjectDetailsResponse>
            {
                FlyBird = false,
                Memory = new ProjectStatusMemory { LastStatus = currentStatus },
                Result = null
            };
        }

        if (!pollingRequest.Memory.LastStatus.Equals(currentStatus, StringComparison.OrdinalIgnoreCase))
        {
            return new PollingEventResponse<ProjectStatusMemory, GetProjectDetailsResponse>
            {
                FlyBird = true,
                Memory = new ProjectStatusMemory { LastStatus = currentStatus },
                Result = new(response)
            };
        }

        return new PollingEventResponse<ProjectStatusMemory, GetProjectDetailsResponse>
        {
            FlyBird = false,
            Memory = new ProjectStatusMemory { LastStatus = currentStatus },
            Result = null
        };
    }
}
