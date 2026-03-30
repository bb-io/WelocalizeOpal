using Tests.Opal.Base;
using Apps.Opal.Handlers;
using Apps.Opal.Models.Identifier;

namespace Tests.Opal;

[TestClass]
public class HandlerTests : TestBase
{
    [TestMethod]
    public async Task ProjectFileDataHandler_ReturnsProcessedProjectFiles()
    {
        // Arrange
        var projectIdentifier = new ProjectIdentifier { ProjectId = "137" };
        var handler = new ProjectFileDataHandler(InvocationContext, projectIdentifier);

        // Act
        var result = await handler.GetDataAsync(new(), default);

        // Assert
        PrintDataHandlerResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task CompletedJobDataHandler_ReturnsJobsWithOutputFiles()
    {
        // Arrange
        var projectIdentifier = new ProjectIdentifier { ProjectId = "136" };
        var handler = new CompletedJobDataHandler(InvocationContext, projectIdentifier);

        // Act
        var result = await handler.GetDataAsync(new(), default);

        // Assert
        PrintDataHandlerResult(result);
        Assert.IsNotNull(result);
    }
}
