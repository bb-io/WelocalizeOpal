using Apps.Opal.Extensions;
using Apps.Opal.Webhooks.Models.Project;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Opal.Webhooks;

[WebhookList("Projects")]
public class ProjectWebhookList
{
    [Webhook("On project completed", Description = "Triggers when a project is completed")]
    public static WebhookResponse<OnProjectCompletedResponse> OnProjectCompleted(WebhookRequest webhookRequest)
    {
        var data = webhookRequest.GetPayload<OnProjectCompletedResponse>();

        return new()
        {
            HttpResponseMessage = null,
            Result = data
        };
    }
}
