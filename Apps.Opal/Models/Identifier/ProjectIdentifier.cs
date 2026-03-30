using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Identifier;

public class ProjectIdentifier
{
    [Display("Project ID")]
    public string ProjectId { get; set; } = string.Empty;
}
