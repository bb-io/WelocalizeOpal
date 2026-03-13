using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Opal.Models.Request.Project;

public class UploadProjectFileRequest
{
    [Display("File")]
    public FileReference File { get; set; }

    [Display("Source locale")]
    public string SourceLocale { get; set; }

    [Display("Target locale")]
    public string TargetLocale { get; set; }
}
