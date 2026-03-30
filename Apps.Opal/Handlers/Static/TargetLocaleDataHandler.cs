using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Opal.Handlers.Static;

public class TargetLocaleDataHandler : IStaticDataSourceItemHandler
{
    public IEnumerable<DataSourceItem> GetData()
    {
        return
        [
            new DataSourceItem("af-ZA", "Afrikaans"),
            new DataSourceItem("am-ET", "Amharic"),
            new DataSourceItem("ar-AA", "Arabic (Generic)"),
            new DataSourceItem("ar-SA", "Arabic (Saudi Arabia)"),
            new DataSourceItem("be-BY", "Belarusian"),
            new DataSourceItem("bg-BG", "Bulgarian"),
            new DataSourceItem("bn-BD", "Bengali (Bangladesh)"),
            new DataSourceItem("bn-IN", "Bengali (India)"),
            new DataSourceItem("ca-ES", "Catalan"),
            new DataSourceItem("cs-CZ", "Czech"),
            new DataSourceItem("cy-GB", "Welsh"),
            new DataSourceItem("da-DK", "Danish"),
            new DataSourceItem("de-AT", "German (Austria)"),
            new DataSourceItem("de-CH", "German (Switzerland)"),
            new DataSourceItem("de-DE", "German (Germany)"),
            new DataSourceItem("el-GR", "Greek"),
            new DataSourceItem("en-AU", "English (Australia)"),
            new DataSourceItem("en-CA", "English (Canada)"),
            new DataSourceItem("en-GB", "English (United Kingdom)"),
            new DataSourceItem("es-001", "Spanish (World)"),
            new DataSourceItem("es-419", "Spanish (Latin America)"),
            new DataSourceItem("es-ES", "Spanish (Spain)"),
            new DataSourceItem("es-MX", "Spanish (Mexico)"),
            new DataSourceItem("es-US", "Spanish (United States)"),
            new DataSourceItem("fa-IR", "Persian (Farsi)"),
            new DataSourceItem("fi-FI", "Finnish"),
            new DataSourceItem("fil-PH", "Filipino"),
            new DataSourceItem("fr-CA", "French (Canada)"),
            new DataSourceItem("fr-FR", "French (France)"),
            new DataSourceItem("he-IL", "Hebrew"),
            new DataSourceItem("hi-IN", "Hindi"),
            new DataSourceItem("hr-HR", "Croatian"),
            new DataSourceItem("hu-HU", "Hungarian"),
            new DataSourceItem("hy-AM", "Armenian"),
            new DataSourceItem("id-ID", "Indonesian"),
            new DataSourceItem("it-IT", "Italian (Italy)"),
            new DataSourceItem("ja-JP", "Japanese"),
            new DataSourceItem("ka-GE", "Georgian"),
            new DataSourceItem("km-KH", "Khmer"),
            new DataSourceItem("kn-IN", "Kannada"),
            new DataSourceItem("ko-KR", "Korean"),
            new DataSourceItem("lb-LU", "Luxembourgish"),
            new DataSourceItem("lt-LT", "Lithuanian"),
            new DataSourceItem("mk-MK", "Macedonian"),
            new DataSourceItem("mn-MN", "Mongolian"),
            new DataSourceItem("ms-MY", "Malay (Malaysia)"),
            new DataSourceItem("nb-NO", "Norwegian Bokmål"),
            new DataSourceItem("nl-BE", "Dutch (Belgium)"),
            new DataSourceItem("nl-NL", "Dutch (Netherlands)"),
            new DataSourceItem("pl-PL", "Polish"),
            new DataSourceItem("pt-BR", "Portuguese (Brazil)"),
            new DataSourceItem("pt-PT", "Portuguese (Portugal)"),
            new DataSourceItem("ro-RO", "Romanian"),
            new DataSourceItem("ru-RU", "Russian"),
            new DataSourceItem("sk-SK", "Slovak"),
            new DataSourceItem("sv-SE", "Swedish"),
            new DataSourceItem("ta-IN", "Tamil"),
            new DataSourceItem("th-TH", "Thai"),
            new DataSourceItem("tl-PH", "Tagalog"),
            new DataSourceItem("tr-TR", "Turkish"),
            new DataSourceItem("uk-UA", "Ukrainian"),
            new DataSourceItem("vi-VN", "Vietnamese"),
            new DataSourceItem("zh-CN", "Chinese Simplified"),
            new DataSourceItem("zh-HK", "Chinese Traditional (Hong Kong)"),
            new DataSourceItem("zh-TW", "Chinese Traditional (Taiwan)")
        ];
    }
}
