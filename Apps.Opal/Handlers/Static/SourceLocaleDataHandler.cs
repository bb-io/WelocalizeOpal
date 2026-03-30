using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Opal.Handlers.Static;

public class SourceLocaleDataHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return
        [
            new DataSourceItem("en-US", "English (United States)"),
            new DataSourceItem("en-GB", "English (United Kingdom)"),
            new DataSourceItem("en-AU", "English (Australia)"),
            new DataSourceItem("en-IN", "English (India)"),
            new DataSourceItem("en-CA", "English (Canada)"),
            new DataSourceItem("es-ES", "Spanish (Spain)"),
            new DataSourceItem("es-419", "Spanish (Latin America)"),
            new DataSourceItem("es-US", "Spanish (United States)"),
            new DataSourceItem("es-MX", "Spanish (Mexico)"),
            new DataSourceItem("es-Intl", "Spanish (International)"),
            new DataSourceItem("fr-FR", "French (France)"),
            new DataSourceItem("fr-CA", "French (Canada)"),
            new DataSourceItem("fr-BE", "French (Belgium)"),
            new DataSourceItem("fr-DZ", "French (Algeria)"),
            new DataSourceItem("de-DE", "German (Germany)"),
            new DataSourceItem("de-CH", "German (Switzerland)"),
            new DataSourceItem("de-AT", "German (Austria)"),
            new DataSourceItem("it-IT", "Italian (Italy)"),
            new DataSourceItem("it-CH", "Italian (Switzerland)"),
            new DataSourceItem("sv-SE", "Swedish (Sweden)"),
            new DataSourceItem("ja-JP", "Japanese (Japan)"),
            new DataSourceItem("zh-Hans", "Simplified Chinese"),
            new DataSourceItem("zh-CN", "Simplified Chinese (China)")
        ];
    }
}
