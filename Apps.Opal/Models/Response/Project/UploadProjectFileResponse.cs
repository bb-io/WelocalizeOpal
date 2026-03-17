using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Response.Project;

public class UploadProjectFileResponse
{
    [Display("File ID"), JsonProperty("id")]
    public string FileId { get; set; } = string.Empty;

    [Display("File name"), JsonProperty("name")]
    public string FileName { get; set; } = string.Empty;

    [Display("Project ID"), JsonProperty("project_id")]
    public string ProjectId { get; set; } = string.Empty;

    [Display("Upload URL"), JsonProperty("upload_url")]
    public string UploadUrl { get; set; } = string.Empty;
}
