namespace PhotoOrganizer.Interfaces;

public interface ISupabaseDataService {

    Task<TagDto> InsertTagAsync(TagDto tagDto);

    Task<IReadOnlyList<TagDto>> GetAllTagsAsync(Guid userId);
}
