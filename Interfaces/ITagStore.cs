namespace PhotoOrganizer.Interfaces;

public interface ITagStore {

    ObservableCollection<Tag> Tags { get; }
}
