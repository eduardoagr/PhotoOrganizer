namespace PhotoOrganizer.Views;

public partial class CreatePhotoView : ContentPage {


    public CreatePhotoView(CreatePhotoViewModel vm) {
        InitializeComponent();
        BindingContext = vm;
    }
}