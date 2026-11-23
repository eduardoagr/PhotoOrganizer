namespace PhotoOrganizer.Views;

public partial class NewTagDialogView : SfPopup {

    private readonly IMessenger Messenger;

    public NewTagDialogView(NewTagDialogViewModel newTagDialogViewModel, IMessenger messenger) {
        InitializeComponent();

        BindingContext = newTagDialogViewModel;

        Messenger = messenger;

        messenger.Register<string>(this, (sender, msg) => {
            if(msg == MessengerKeys.CloseNewTagDialog)
                IsOpen = false;
        });
    }
}