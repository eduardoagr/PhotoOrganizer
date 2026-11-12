namespace PhotoOrganizer.Services;

public class TagService(IDataServices dataServices) : ITagService {

    public async Task<IEnumerable<Tag>> GetTagsAsync() {
        return await dataServices.GetTagsAsync();
    }

    public async Task<Tag> CreateTagAsync(string name, string color) {
        var newTag = new Tag {
            Name = name,
            Color = color
        };

        await dataServices.SaveTagAsync(newTag);

        return newTag;
    }
}
