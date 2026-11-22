namespace PhotoOrganizer.Interfaces;

public static class InitialTagsService {

    public static readonly List<TagDto> InitialTags = [
         new TagDto { Name = "Work", Color = "#4285F4" },
         new TagDto { Name = "Home", Color = "#FF9800" },
         new TagDto { Name = "Personal", Color = "#E91E63" },
         new TagDto { Name = "Study", Color = "#9C27B0" },
         new TagDto { Name = "All", Color = "#78909C" },
         new TagDto { Name = "New tag", Color = "#4CAF50" }
    ];
}
