using RestSharp;
using Apps.Opal.Models.Entities;
using Apps.Opal.Models.Identifier;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Opal.Handlers;

public class ProjectFileDataHandler(
    InvocationContext invocationContext,
    [ActionParameter] ProjectIdentifier projectIdentifier) 
    : OpalInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(projectIdentifier.ProjectId))
            throw new PluginMisconfigurationException("Please specify the project ID first");

        if (!int.TryParse(projectIdentifier.ProjectId, out var projectId))
        {
            throw new PluginMisconfigurationException(
                @"Please specify a valid project ID integer.
                The 'Project ID' value must not be passed from outputs of previous actions or events
                to perform a search during the bird building");
        }

        var request = new RestRequest($"projects/{projectId}");
        var response = await Client.ExecuteWithErrorHandling<ProjectEntity>(request);

        var processedFiles = response.Files.Where(x => x.FileType is "output" or "final");
        return processedFiles.Select(x => new DataSourceItem(x.FileId, x.ToString())).ToList();
    }
}
