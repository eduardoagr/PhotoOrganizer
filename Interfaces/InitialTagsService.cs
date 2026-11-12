namespace PhotoOrganizer.Interfaces;

public static class InitialTagsService {

    public static readonly List<TagDto> InitialTags = [
         new TagDto { TagName = "Work", Color = "#4285F4" },
         new TagDto { TagName = "Home", Color = "#FF9800" },
         new TagDto { TagName = "Personal", Color = "#E91E63" },
         new TagDto { TagName = "Study", Color = "#9C27B0" },
         new TagDto { TagName = "All", Color = "#78909C" },
         new TagDto { TagName = "New tag", Color = "#4CAF50" }
    ];
}
