using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Request;

public class CreateProjectRequest
{
    [Display("Content group ID")]
    public string ContentGroupId { get; set; }

    [Display("Orchestrator project ID", Description = "Must be unique")]
    public string OrchestratorProjectId { get; set; }
}
