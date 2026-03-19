namespace Apps.Opal.Webhooks.Models;

public class BridgeWebhookPayload<T>
{
    public Dictionary<string, string> Parameters { get; set; } = [];
    public T? Payload { get; set; }
}