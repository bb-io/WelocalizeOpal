using Apps.Opal.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apps.Opal.Models.Error;

public class ErrorResponse
{
    [JsonProperty("detail")]
    public JToken? Detail { get; set; }

    [JsonIgnore]
    public string Message => Detail switch
    {
        null => string.Empty,
        JArray items => string.Join("; ", items.Select(FormatItem)),
        _ => Detail.AsText()
    };

    private static string FormatItem(JToken item)
    {
        if (item is not JObject obj || obj["msg"] is not { } msg)
            return item.AsText();

        return obj["loc"] is JArray loc
            ? $"{string.Join(".", loc)}: {msg}"
            : msg.ToString();
    }
}
