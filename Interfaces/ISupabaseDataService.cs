namespace PhotoOrganizer.Interfaces;

public interface ISupabaseDataService {

    Task<TagDto> InsertTagAsync(TagDto tagDto);

    Task<IReadOnlyList<PhotoDto>> GetAllPhotosAsync();

    Task<IReadOnlyList<PhotoDto>> GetPhotosByTagAsync(int tagId);

    Task<PhotoDto?> GetPhotoByIdAsync(long id);

    Task<PhotoDto> InsertPhotoAsync(PhotoDto dto);

    Task<IReadOnlyList<TagDto>> GetAllTagsAsync(Guid userId);
}
