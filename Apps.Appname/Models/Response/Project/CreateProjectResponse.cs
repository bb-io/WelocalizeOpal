using Apps.Opal.Models.Entities;

namespace Apps.Opal.Models.Response.Project;

public class CreateProjectResponse(ProjectEntity projectEntity) : BaseProjectResponse(projectEntity);