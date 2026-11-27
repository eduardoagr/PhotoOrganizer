namespace PhotoOrganizer.Interfaces;

public interface ISupabaseDataService {

    Task<PhotoDto> InsertPhotoAsync(PhotoDto photoDto);

    Task<IEnumerable<PhotoDto>> GetPhotosAsync();

    Task<IEnumerable<PhotoDto>> GetPhotosByTagAsync(long tagId);
}
