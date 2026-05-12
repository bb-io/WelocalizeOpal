using Apps.Opal.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Opal.Models.Request.Project;

public class SearchProjectFilesRequest
{
    [Display("File types"), StaticDataSource(typeof(FileTypeDataHandler))]
    public IEnumerable<string>? FileTypes { get; set; }
}