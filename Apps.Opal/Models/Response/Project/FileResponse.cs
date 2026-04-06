using Apps.Opal.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Opal.Models.Response.Project;

public class FileResponse(FileEntity fileEntity)
{
    [Display("File ID")]
    public string FileId { get; set; } = fileEntity.FileId;

    [Display("File name")]
    public string FileName { get; set; } = fileEntity.FileName;

    [Display("File type")]
    public string FileType { get; set; } = fileEntity.FileType;

    [Display("Job ID")]
    public string JobId { get; set; } = fileEntity.JobId;

    [Display("Source locale")]
    public string SourceLocale { get; set; } = fileEntity.SourceLocale;

    [Display("Target locale")]
    public string TargetLocale { get; set; } = fileEntity.TargetLocale;

    [Display("Download URL")]
    public string? DownloadUrl { get; set; } = fileEntity.DownloadUrl;
}
