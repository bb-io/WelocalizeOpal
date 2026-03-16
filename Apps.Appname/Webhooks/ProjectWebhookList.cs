using System.Net;
using Apps.Opal.Extensions;
using Apps.Opal.Models.Identifier;
using Apps.Opal.Webhooks.Models.Project;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Opal.Webhooks;

[WebhookList("Projects")]
public class ProjectWebhookList
{
    [Webhook("On project completed", Description = "Triggers when a project is completed")]
    public static WebhookResponse<OnProjectCompletedResponse> OnProjectCompleted(
        WebhookRequest webhookRequest,
        [WebhookParameter] ProjectIdentifier projectIdentifier)
    {
        var data = webhookRequest.GetPayload<OnProjectCompletedResponse>();

        if (data.ProjectId != projectIdentifier.ProjectId)
        {
            return new()
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        return new()
        {
            HttpResponseMessage = null,
            Result = data
        };
    }
}
