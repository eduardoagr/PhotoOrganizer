namespace PhotoOrganizer.Views;

public partial class GalleryView : ContentPage {
    public GalleryView(GalleryViewModel notesViewModel) {
        InitializeComponent();

        BindingContext = notesViewModel;
    }
}