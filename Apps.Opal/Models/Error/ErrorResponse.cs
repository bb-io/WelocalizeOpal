using Newtonsoft.Json;

namespace Apps.Opal.Models.Error;

public class ErrorResponse
{
    [JsonProperty("detail")]
    public string Detail { get; set; } = string.Empty;
}
