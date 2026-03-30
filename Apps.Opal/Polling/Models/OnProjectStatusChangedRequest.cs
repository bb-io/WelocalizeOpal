using Apps.Opal.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Opal.Polling.Models;

public class OnProjectStatusChangedRequest
{
    [Display("Project status"), StaticDataSource(typeof(ProjectStatusDataHandler))]
    public string? ProjectStatus { get; set; }
}
