namespace PhotoOrganizer.Services;

public class TagService : ITagService {
    public Task<Tag> CreateTagAsync(string name, string color) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tag>> GetTagsAsync() {
        throw new NotImplementedException();
    }
}
