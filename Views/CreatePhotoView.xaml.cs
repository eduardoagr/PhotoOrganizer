namespace PhotoOrganizer.Views;

public partial class CreatePhotoView : ContentPage {


    public CreatePhotoView(CreatePhotoViewModel vm) {
        InitializeComponent();
        BindingContext = vm;
    }

    private void TagsCombo_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e) {

        if(BindingContext is not CreatePhotoViewModel vm)
            return;

        if(e.AddedItems?.FirstOrDefault() is not Tag tag) {
            return;
        }

        vm.SelectedTag = tag;

        if(tag.Name == "New tag") {
            vm.CreateNewTag();
            return;
        }
    }
}