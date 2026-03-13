using Newtonsoft.Json;

namespace Apps.Opal.Webhooks.Models;

public class WebhookWrapper<T>
{
    [JsonProperty("event_type")]
    public string EventType { get; set; } = string.Empty;

    [JsonProperty("data")]
    public T? Data { get; set; }
}
