using Newtonsoft.Json;
using Apps.Opal.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Opal.Extensions;

public static class WebhookRequestExtensions
{
    public static T GetBridgePayload<T>(this WebhookRequest request)
    {
        string body = request.Body?.ToString()!;
        var response = JsonConvert.DeserializeObject<BridgeWebhookPayload<WebhookWrapper<T>>>(body);
        return response!.Payload!.Data!;
    }
}
