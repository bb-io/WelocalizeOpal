using Tests.Opal.Base;
using Apps.Opal.Actions;
using Apps.Opal.Models.Request;

namespace Tests.Opal;

[TestClass]
public class ProjectTests : TestBase
{
    private readonly ProjectActions _actions;

    public ProjectTests() => _actions = new ProjectActions(InvocationContext, FileManager);

    [TestMethod]
    public async Task CreateProject_ReturnsCreatedProject()
    {
        // Arrange
        var input = new CreateProjectRequest
        {
            ContentGroupId = "34",
            OrchestratorProjectId = "testproj_bb_tests4"
        };

        // Act
        var result = await _actions.CreateProject(input);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }
}
