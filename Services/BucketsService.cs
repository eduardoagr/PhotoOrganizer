using Supabase;

namespace PhotoOrganizer.Services;

public class BucketsService(Client _client) : IBucketsService {
    private const string BucketName = "Images";

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