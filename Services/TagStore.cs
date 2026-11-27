namespace PhotoOrganizer.Services;

public class TagStore : ITagStore {

    public ObservableCollection<Tag> Tags { get; } = [];
}
