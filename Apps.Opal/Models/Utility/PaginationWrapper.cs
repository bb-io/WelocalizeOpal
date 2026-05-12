using Newtonsoft.Json;

namespace Apps.Opal.Models.Utility;

public class PaginationWrapper<T>
{
    [JsonProperty("results")]
    public IEnumerable<T> Results { get; set; } = [];
}