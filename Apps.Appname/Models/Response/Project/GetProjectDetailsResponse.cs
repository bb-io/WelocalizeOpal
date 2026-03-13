using Apps.Opal.Models.Entities;

namespace Apps.Opal.Models.Response.Project;

public class GetProjectDetailsResponse(ProjectEntity projectEntity) : BaseProjectResponse(projectEntity)
{
    public IEnumerable<FileResponse> Files { get; set; } = projectEntity.Files.Select(x => new FileResponse(x));
}
