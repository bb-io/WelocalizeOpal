using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Webhooks.Models.Project;

public class OnProjectCompletedResponse
{
    [Display("Project ID"), JsonProperty("project_id")]
    public string ProjectId { get; set; } = string.Empty;

    [Display("Orchestrator project ID"), JsonProperty("orchestrator_project_id")]
    public string OrchestratorProjectId { get; set; } = string.Empty;

    [Display("Customer ID"), JsonProperty("customer_id")]
    public string CustomerId { get; set; } = string.Empty;

    [Display("Completed at"), JsonProperty("completed_at")]
    public DateTime CompletedAt { get; set; }
}
