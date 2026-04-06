using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Apps.Opal.Models.Identifier;

public class ProjectIdentifier
{
    [Display("Project ID")]
    public string ProjectId { get; set; } = string.Empty;

    public ProjectIdentifier Validate()
    {
        if (string.IsNullOrEmpty(ProjectId))
            throw new PluginMisconfigurationException("Please specify the project ID first");

        if (!int.TryParse(ProjectId, out var projectId))
        {
            throw new PluginMisconfigurationException(
                @"Please specify a valid project ID integer.
                The 'Project ID' value must not be passed from outputs of previous actions or events
                to perform a search during the bird building");
        }

        return this;
    }
}