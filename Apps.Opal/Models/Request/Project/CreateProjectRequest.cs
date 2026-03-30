using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Request.Project;

public class CreateProjectRequest
{
    [Display("Orchestrator project ID", Description = "Must be unique")]
    public string OrchestratorProjectId { get; set; }
}
