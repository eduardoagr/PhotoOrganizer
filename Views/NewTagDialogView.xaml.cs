namespace PhotoOrganizer.Views;

public partial class NewTagDialogView : SfPopup {

    public NewTagDialogView(NewTagDialogViewModel newTagDialogViewModel, IMessenger messenger) {
        InitializeComponent();

        BindingContext = newTagDialogViewModel;
    }
}