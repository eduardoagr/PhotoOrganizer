namespace PhotoOrganizer.Constants;

public static class TagsSeed {
    public static readonly ObservableCollection<Tag> InitialTags = [
        new Tag { Name = "Family", Color = "#EC407A" },
        new Tag { Name = "Friends", Color = "#26A69A" },
        new Tag { Name = "Personal", Color = "#5C6BC0" },
        new Tag { Name = "Travel", Color = "#AB47BC" },
        new Tag { Name = "Work", Color = "#FF7043" }
    ];
}
