using Newtonsoft.Json;

namespace Apps.Opal.Models.Entities;

public class FileEntity
{
    [JsonProperty("id")]
    public string FileId { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string FileName { get; set; } = string.Empty;

    [JsonProperty("job_id")]
    public string JobId { get; set; } = string.Empty;

    [JsonProperty("type")]
    public string FileType { get; set; } = string.Empty;

    [JsonProperty("source_locale")]
    public string SourceLocale { get; set; } = string.Empty;

    [JsonProperty("target_locale")]
    public string TargetLocale { get; set; } = string.Empty;

    [JsonProperty("download_url")]
    public string DownloadUrl { get; set; } = string.Empty;
}
