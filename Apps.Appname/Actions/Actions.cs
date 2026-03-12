using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Opal.Actions;

[ActionList]
public class Actions(InvocationContext invocationContext) : OpalInvocable(invocationContext)
{
    [Action("Action", Description = "Describes the action")]
    public async Task Action()
    {
        
    }
}