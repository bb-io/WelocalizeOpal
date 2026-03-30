using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.Opal.Helper;

public static class FileManagementHelper
{
    public static async Task<byte[]> DownloadFile(FileReference file, IFileManagementClient fileManagementClient)
    {
        using var fileStream = await fileManagementClient.DownloadAsync(file);
        using var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
