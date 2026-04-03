using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Opal.Handlers;

public class TestDataHandler(InvocationContext invocationContext) : OpalInvocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken ct)
    {
        return await Task.FromResult(new List<DataSourceItem>());
    }
}
