using Apps.Opal.Actions;
using Tests.Opal.Base;

namespace Tests.Opal;

[TestClass]
public class ActionTests : TestBase
{
    [TestMethod]
    public async Task Dynamic_handler_works()
    {
        var actions = new Actions(InvocationContext);

        await actions.Action();
    }
}
