namespace PhotoOrganizer.Views;

public partial class NewTagDialogView : SfPopup {

    private IMessenger? Messenger;

    public NewTagDialogView() {
        InitializeComponent();
    }

    public NewTagDialogView(NewTagDialogViewModel newTagDialogViewModel, IMessenger messenger) {
        InitializeComponent();
        BindingContext = newTagDialogViewModel;

        Messenger = messenger;

        messenger.Register<string>(this, (sender, msg) => {
            IsOpen = false;
        });
    }
}