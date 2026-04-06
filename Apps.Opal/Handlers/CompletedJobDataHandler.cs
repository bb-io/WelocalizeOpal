using Apps.Opal.Models.Entities;
using Apps.Opal.Models.Identifier;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Opal.Handlers;

public class CompletedJobDataHandler(
    InvocationContext invocationContext,
    [ActionParameter] ProjectIdentifier projectIdentifier) 
    : OpalInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken ct)
    {
        projectIdentifier.Validate();

        var request = new RestRequest($"projects/{projectIdentifier.ProjectId}");
        var response = await Client.ExecuteWithErrorHandling<ProjectEntity>(request);

        var jobs = response.Files
            .Where(x => x.FileType is "output")
            .Select(x => new { x.JobId, x.FileName, x.SourceLocale, x.TargetLocale });

        return jobs
            .Select(x => new DataSourceItem(x.JobId, $"{x.FileName} (Source: {x.SourceLocale}, target: {x.TargetLocale})"))
            .Where(x => 
                context.SearchString == null || 
                x.DisplayName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase)) 
            .ToList();
    }
}
