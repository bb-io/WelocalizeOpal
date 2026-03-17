using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Opal.Models.Request.Project;

public class CompleteProjectRequest
{
    [Display("Final files")]
    public IEnumerable<FileReference> Files { get; set; }
}
