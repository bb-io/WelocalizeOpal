using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Opal.Extensions;

public static class InvocationContextExtensions
{
    public static string GetCustomBridgeUrl(this InvocationContext invocationContext)
    {
        return $"{invocationContext.UriInfo.BridgeServiceUrl.ToString().TrimEnd('/')}/webhooks/opal";
    }
}
