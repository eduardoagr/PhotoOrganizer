using Supabase;

namespace PhotoOrganizer.Services;

public class BucketsService(Client _client) : IBucketsService {
    private const string BucketName = "Images";

    public async Task<string> UploadFileAsync(
        string localFilePath,
        string deviceId,
        string title) {
        var fileName = $"{title}.jpg";

        var remotePath = $"{deviceId}/{fileName}";

        await _client.Storage
            .From(BucketName)
            .Upload(localFilePath, remotePath);

        // Generate the full public URL
        var imageUrl = _client.Storage
            .From(BucketName)
            .GetPublicUrl(remotePath);

        return imageUrl;
    }
}