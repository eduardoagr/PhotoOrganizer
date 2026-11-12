namespace PhotoOrganizer.Interfaces;

public interface IDataServices {

    Task InitAsync();

    Task<IEnumerable<Tag>> GetTagsAsync();

    Task<string?> GetTagNameAsync(int tagId);

    Task SaveTagAsync(Tag tag);

    Task<IEnumerable<Photo>> GetAllPhotosAsync();

    Task SavePhotoAsync(Photo p);

    Task<IEnumerable<Tag>> SeedTagsAsync();


}
