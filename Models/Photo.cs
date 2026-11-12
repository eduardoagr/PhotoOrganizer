namespace PhotoOrganizer.Models;

public partial class Photo : ObservableObject {

    public long Id { get; set; }

    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Description { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LocationDescription { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string? PhotoPath { get; set; } = null;

    [ObservableProperty]
    public partial int TagId { get; set; }

    [ObservableProperty]
    public partial string? CreatedAt { get; set; } = DateTime.UtcNow.ToString("D");

    public string DeviceId { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}
