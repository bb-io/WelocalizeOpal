using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Opal.Handlers.Static;

public class ProjectStatusDataHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return 
        [
            new DataSourceItem("started", "Started"),
            new DataSourceItem("finished", "Finished"),
            new DataSourceItem("canceled", "Canceled"),
            new DataSourceItem("failed", "Failed"),
        ];
    }
}
