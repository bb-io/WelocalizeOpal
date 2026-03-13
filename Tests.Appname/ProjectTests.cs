using Tests.Opal.Base;
using Apps.Opal.Actions;
using Apps.Opal.Models.Identifier;
using Apps.Opal.Models.Request.Project;
using Blackbird.Applications.Sdk.Common.Files;

namespace Tests.Opal;

[TestClass]
public class ProjectTests : TestBase
{
    private readonly ProjectActions _actions;

    public ProjectTests() => _actions = new ProjectActions(InvocationContext, FileManager);

    [TestMethod]
    public async Task GetProjectDetails_ReturnsProjectDetails()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "125" };

        // Act
        var result = await _actions.GetProjectDetails(projectId);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task CreateProject_ReturnsCreatedProject()
    {
        // Arrange
        var input = new CreateProjectRequest
        {
            OrchestratorProjectId = "testproj_bb_tests4"
        };

        // Act
        var result = await _actions.CreateProject(input);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task UploadProjectFile_ReturnsUploadedFileDetails()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "119" };
        var input = new UploadProjectFileRequest
        {
            SourceLocale = "en-US",
            TargetLocale = "pl-PL",
            File = new FileReference { Name = "test.mxliff" }
        };

        // Act
        var result = await _actions.UploadProjectFile(projectId, input);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task StartProject_IsSuccess()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "119" };

        // Act
        await _actions.StartProject(projectId);

        // Assert
        var startedProject = await _actions.GetProjectDetails(projectId);
        Assert.AreEqual("started", startedProject.Status);
    }

    [TestMethod]
    public async Task CancelProject_IsSuccess()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "119" };

        // Act
        await _actions.CancelProject(projectId);

        // Assert
        var startedProject = await _actions.GetProjectDetails(projectId);
        Assert.AreEqual("canceled", startedProject.Status);
    }
}
