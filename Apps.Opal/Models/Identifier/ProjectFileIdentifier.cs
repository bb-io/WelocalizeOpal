using Apps.Opal.Handlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Opal.Models.Identifier;

public class ProjectFileIdentifier
{
    [Display("File ID"), DataSource(typeof(ProjectFileDataHandler))]
    public string ProjectFileId { get; set; }
}
