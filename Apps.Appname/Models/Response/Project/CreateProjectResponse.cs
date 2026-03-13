using Apps.Opal.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Response.Project;

public class CreateProjectResponse(ProjectEntity entity) : BaseProjectResponse(entity)
{
    [Display("Content group ID")]
    public string ContentGroupId { get; set; } = entity.ContentGroupId;
}