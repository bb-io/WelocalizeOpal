using Apps.Opal.Handlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Opal.Models.Request.Project;

public class CreateProjectRequest
{
    [Display("Orchestrator project ID", Description = "Must be unique")]
    public string OrchestratorProjectId { get; set; } = string.Empty;

    [Display("Content group name"), DataSource(typeof(ContentGroupNameDataHandler))]
    public string ContentGroupName { get; set; } = string.Empty;
}
