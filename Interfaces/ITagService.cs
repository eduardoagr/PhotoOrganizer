namespace PhotoOrganizer.Interfaces;

public interface ITagService {

    Task<IEnumerable<Tag>> GetTagsAsync();

    Task<Tag> CreateTagAsync(string name, string color);
}
