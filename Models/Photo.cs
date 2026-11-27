namespace PhotoOrganizer.Models;

public partial class Photo : ObservableObject {

    public int Id { get; set; }

    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Description { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LocationDescription { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string? PhotoPath { get; set; } = null;

    [ObservableProperty]
    public partial long? TagId { get; set; }

    [ObservableProperty]
    public partial DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

    public string FilePath { get; set; } = string.Empty;
}
