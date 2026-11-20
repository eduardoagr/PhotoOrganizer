
using System.Windows.Input;

namespace PhotoOrganizer.Controls;

public partial class PhotoCaptureCard : ContentView {
    public PhotoCaptureCard() {
        InitializeComponent();
    }

    public static readonly BindableProperty PhotoPathProperty =
        BindableProperty.Create(
            nameof(PhotoPath),
            typeof(string),
            typeof(PhotoCaptureCard),
            default(string));

    public string? PhotoPath {
        get => (string?)GetValue(PhotoPathProperty);
        set => SetValue(PhotoPathProperty, value);
    }

    public static readonly BindableProperty IsPhotoEmptyProperty =
        BindableProperty.Create(
            nameof(IsPhotoEmpty),
            typeof(bool),
            typeof(PhotoCaptureCard),
            true);

    public bool IsPhotoEmpty {
        get => (bool)GetValue(IsPhotoEmptyProperty);
        set => SetValue(IsPhotoEmptyProperty, value);
    }

    public static readonly BindableProperty IsPhotoTakenProperty =
        BindableProperty.Create(
            nameof(IsPhotoTaken),
            typeof(bool),
            typeof(PhotoCaptureCard),
            false);

    public bool IsPhotoTaken {
        get => (bool)GetValue(IsPhotoTakenProperty);
        set => SetValue(IsPhotoTakenProperty, value);
    }

    public static readonly BindableProperty LocationProperty =
        BindableProperty.Create(
            nameof(Location),
            typeof(string),
            typeof(PhotoCaptureCard),
            string.Empty);

    public string Location {
        get => (string)GetValue(LocationProperty);
        set => SetValue(LocationProperty, value);
    }

    public static readonly BindableProperty CaptureCommandProperty =
        BindableProperty.Create(
            nameof(CaptureCommand),
            typeof(ICommand),
            typeof(PhotoCaptureCard));

    public ICommand? CaptureCommand {
        get => (ICommand?)GetValue(CaptureCommandProperty);
        set => SetValue(CaptureCommandProperty, value);
    }
}
