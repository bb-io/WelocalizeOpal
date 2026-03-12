using Newtonsoft.Json;

namespace Apps.Opal.Models.Entities;

public class ProjectEntity
{
    [JsonProperty("id")]
    public string ProjectId { get; set; } = string.Empty;

    [JsonProperty("orchestrator_project_id")]
    public string OrchestratorProjectId { get; set; } = string.Empty;

    [JsonProperty("customer_id")]
    public string CustomerId { get; set; } = string.Empty;

    [JsonProperty("content_group_id")]
    public string ContentGroupId { get; set; } = string.Empty;

    [JsonProperty("orchestrator")]
    public string Orchestrator { get; set; } = string.Empty;

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("fail_reason")]
    public string? FailReason { get; set; }

    [JsonProperty("completed_at")]
    public DateTime? CompletedAt { get; set; }

    [JsonProperty("expires_at")]
    public DateTime ExpiresAt { get; set; }
}
