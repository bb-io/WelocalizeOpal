using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Opal.Handlers.Static;

public class FileTypeDataHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return 
        [
            new DataSourceItem("input", "Input"),
            new DataSourceItem("output", "Output"),
            new DataSourceItem("final", "Final")
        ];
    }
}