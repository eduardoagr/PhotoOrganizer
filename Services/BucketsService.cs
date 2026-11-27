namespace PhotoOrganizer.Services;

public class BucketsService(Client _client, HttpClient httpClient) : IBucketsService {

    private const string BucketName = "Images";

    public async Task<string?> DownloadAsync(string fileUrl) {

        try {
            var fileName = Path.GetFileName(new Uri(fileUrl).LocalPath);
            var localPath = Path.Combine(FileSystem.CacheDirectory, fileName);

            await using var stream = await httpClient.GetStreamAsync(fileUrl);
            await using var file = File.Create(localPath);

            await stream.CopyToAsync(file);

            return localPath;

        } catch {

            return null;
        }
    }

    public async Task<string> UploadFileAsync(string localFilePath, string fileName) {

        var userId = _client.Auth.CurrentSession!.User!.Id;

        var remotePath = $"{userId}/{fileName}.jpg";

        await _client.Storage
            .From(BucketName)
            .Upload(localFilePath, remotePath);

        return _client.Storage
            .From(BucketName)
            .GetPublicUrl(remotePath);
    }
}