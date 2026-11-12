namespace PhotoOrganizer.Models;

public partial class Tag : ObservableObject {

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Color { get; set; } = "#4285F4";

    [ObservableProperty]
    public partial bool isSelected { get; set; }
}
