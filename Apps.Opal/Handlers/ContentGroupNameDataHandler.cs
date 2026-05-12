using Apps.Opal.Models.Entities;
using Apps.Opal.Models.Utility;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Opal.Handlers;

public class ContentGroupNameDataHandler(InvocationContext context) : OpalInvocable(context), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken ct)
    {
        var request = new RestRequest("my/content-groups");
        request.AddParameter("limit", 50);

        if (!string.IsNullOrWhiteSpace(context.SearchString))
            request.AddParameter("name", context.SearchString);

        var response = await Client.ExecuteWithErrorHandling<PaginationWrapper<ContentGroupEntity>>(request);
        return response.Results.Select(x => new DataSourceItem(x.Name, x.Name)).ToList();
    }
}