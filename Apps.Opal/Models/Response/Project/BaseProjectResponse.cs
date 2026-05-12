using Apps.Opal.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Response.Project;

public class BaseProjectResponse(ProjectEntity entity)
{
    [Display("Project ID")]
    public string ProjectId { get; set; } = entity.ProjectId;

    [Display("Orchestrator project ID")]
    public string OrchestratorProjectId { get; set; } = entity.OrchestratorProjectId;

    [Display("Customer ID")]
    public string CustomerId { get; set; } = entity.CustomerId;

    [Display("Orchestrator")]
    public string Orchestrator { get; set; } = entity.Orchestrator;

    [Display("Content group ID")]
    public string ContentGroupId { get; set; } = entity.ContentGroupId;

    [Display("Content group name")]
    public string ContentGroupName { get; set; } = entity.ContentGroupName;

    [Display("Status")]
    public string Status { get; set; } = entity.Status;

    [Display("Fail reason")]
    public string? FailReason { get; set; } = entity.FailReason;

    [Display("Completed at")]
    public DateTime? CompletedAt { get; set; } = entity.CompletedAt;

    [Display("Expires at")]
    public DateTime ExpiresAt { get; set; } = entity.ExpiresAt;
}
