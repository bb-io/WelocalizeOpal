using Newtonsoft.Json;

namespace Apps.Opal.Models.Entities;

public class ContentGroupEntity
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}