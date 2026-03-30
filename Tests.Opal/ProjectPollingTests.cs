using Tests.Opal.Base;
using Apps.Opal.Polling;
using Apps.Opal.Polling.Models;
using Apps.Opal.Polling.Memories;
using Apps.Opal.Models.Identifier;
using Blackbird.Applications.Sdk.Common.Polling;

namespace Tests.Opal;

[TestClass]
public class ProjectPollingTests : TestBase
{
	private readonly ProjectPollingList _pollingList;

	public ProjectPollingTests() => _pollingList = new ProjectPollingList(InvocationContext);

    [TestMethod]
    public async Task OnProjectStatusChanged_ReturnsUpdatedProjectStatuses()
    {
		// Arrange
		var projectInput = new ProjectIdentifier { ProjectId = "139" };
		var input = new OnProjectStatusChangedRequest { ProjectStatus = "finished" };
		var memory = new ProjectStatusMemory { LastStatus = "created" };
		var pollingRequest = new PollingEventRequest<ProjectStatusMemory> { Memory = memory };

		// Act
		var result = await _pollingList.OnProjectStatusChanged(pollingRequest, projectInput, input);

		// Assert
		PrintJsonResult(result);
	}
}
