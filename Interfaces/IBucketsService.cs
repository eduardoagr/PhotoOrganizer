namespace PhotoOrganizer.Interfaces;

public interface IBucketsService {

    Task<string> UploadFileAsync(string localFilePath, string deviceId, string title);

}


