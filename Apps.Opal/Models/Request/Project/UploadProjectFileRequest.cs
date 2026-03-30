using Apps.Opal.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Opal.Models.Request.Project;

public class UploadProjectFileRequest
{
    [Display("File")]
    public FileReference File { get; set; } = null!;

    [Display("Source locale"), StaticDataSource(typeof(SourceLocaleDataHandler))]
    public string SourceLocale { get; set; } = string.Empty;

    [Display("Target locale"), StaticDataSource(typeof(TargetLocaleDataHandler))]
    public string TargetLocale { get; set; } = string.Empty;
}
