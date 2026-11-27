namespace PhotoOrganizer.Interfaces;

public interface IBucketsService {

    Task<string> UploadFileAsync(string localFilePath, string fileName);

    Task<string?> DownloadAsync(string fileUrl);

}


