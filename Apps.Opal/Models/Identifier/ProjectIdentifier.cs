using Apps.Opal.Handlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Opal.Models.Identifier;

public class ProjectIdentifier
{
    [Display("Project ID"), DataSource(typeof(TestDataHandler))]
    public string ProjectId { get; set; } = string.Empty;
}
