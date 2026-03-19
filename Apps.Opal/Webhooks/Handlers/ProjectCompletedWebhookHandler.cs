using Apps.Opal.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Opal.Webhooks.Handlers;

public class ProjectCompletedWebhookHandler(InvocationContext invocationContext) : WebhookHandler(invocationContext)
{
    protected override string Event => "completed";
}
