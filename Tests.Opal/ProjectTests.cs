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
        var projectId = new ProjectIdentifier { ProjectId = "826" };

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
            OrchestratorProjectId = "testproj_bb_tests7",
            ContentGroupName = "blackbird-integration-testing"
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
        var projectId = new ProjectIdentifier { ProjectId = "139" };
        var input = new UploadProjectFileRequest
        {
            SourceLocale = "en-US",
            TargetLocale = "nl-NL",
            File = new FileReference { Name = "testNl.mxliff" }
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
        var projectId = new ProjectIdentifier { ProjectId = "139" };

        // Act
        await _actions.StartProject(projectId);

        // Assert
        await AssertProjectStatus(projectId, "started");
    }

    [TestMethod]
    public async Task CancelProject_IsSuccess()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "119" };

        // Act
        await _actions.CancelProject(projectId);

        // Assert
        await AssertProjectStatus(projectId, "canceled");
    }

    [TestMethod]
    public async Task CompleteProject_IsSuccess()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "139" };
        var request = new CompleteProjectRequest
        {
            Files = [new FileReference { Name = "testNl.mxliff" }],
            JobIds = ["415"]
        };

        // Act
        await _actions.CompleteProject(projectId, request);
    }

    [TestMethod]
    public async Task DownloadProjectFile_IsSuccess()
    {
        // Arrange
        var projectId = new ProjectIdentifier { ProjectId = "248" };
        var fileId = new ProjectFileIdentifier { ProjectFileId = "123" };

        // Act
        var result = await _actions.DownloadProjectFile(projectId, fileId);

        // Assert
        Console.WriteLine(result.Content.Name);
        Assert.IsNotNull(result.Content);
    }

    private async Task AssertProjectStatus(ProjectIdentifier projectId, string status)
    {
        var startedProject = await _actions.GetProjectDetails(projectId);
        Assert.AreEqual(status, startedProject.Status);
    }
}
