using Apps.Opal.Handlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Apps.Opal.Models.Request.Project;

public class CompleteProjectRequest
{
    [Display("Final files")]
    public List<FileReference> Files { get; set; } = [];

    [Display("Job IDs", Description = "The order of the files must match the order of the job IDs being finalized")]
    [DataSource(typeof(CompletedJobDataHandler))]
    public List<string> JobIds { get; set; } = [];

    public CompleteProjectRequest Validate()
    {
        if (Files.Count != JobIds.Count)
        {
            throw new PluginMisconfigurationException(
                "The order of the input files must match the order of the job IDs being finalized");
        }

        return this;
    }
}
