using Apps.Opal.Extensions;
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
        var request = new RestRequest("my/content-groups")
            .AddParameter("limit", 50);
        
        // Will throw an error if search string is less than 2 chars
        if (context.SearchString?.Trim().Length >= 2)
            request.AddParameter("name", context.SearchString.Trim());

        var response = await Client.ExecuteWithErrorHandling<PaginationWrapper<ContentGroupEntity>>(request);
        return response.Results
            .Where(x => x.Name.Matches(context.SearchString))
            .Select(x => new DataSourceItem(x.Name, x.Name))
            .ToList();
    }
}