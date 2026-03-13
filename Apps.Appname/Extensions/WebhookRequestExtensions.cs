using Newtonsoft.Json;
using Apps.Opal.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Opal.Extensions;

public static class WebhookRequestExtensions
{
    public static T GetPayload<T>(this WebhookRequest request)
    {
        string body = request.Body?.ToString()!;
        var response = JsonConvert.DeserializeObject<WebhookWrapper<T>>(body);
        return response!.Data!;
    }
}
