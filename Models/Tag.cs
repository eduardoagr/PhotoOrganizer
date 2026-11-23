namespace PhotoOrganizer.Models;

public partial class Tag : ObservableObject {

    public int Id { get; set; }

    [ObservableProperty]
    public partial string Name { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Color { get; set; } = "#4285F4";

    [ObservableProperty]
    public partial bool IsSelected { get; set; }

    public Color MauiColor {
        get => Microsoft.Maui.Graphics.Color.FromArgb(Color);
        set {
            Color = value.ToArgbHex();
            OnPropertyChanged();
        }
    }
}
