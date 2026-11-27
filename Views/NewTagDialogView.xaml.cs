namespace PhotoOrganizer.Views;

public partial class NewTagDialogView : SfPopup {
    private readonly IMessenger Messenger;

    public NewTagDialogView(NewTagDialogViewModel newTagDialogViewModel, IMessenger messenger) {
        InitializeComponent();

        BindingContext = newTagDialogViewModel;

        Messenger = messenger;

        messenger.Register<string>(this, (sender, msg) => {
            if(msg == MessengerKeys.ClosePopup)
                IsOpen = false;
        });
    }

    private void RootPopup_Closed(object sender, EventArgs e) {

        if(BindingContext is NewTagDialogViewModel vm) {
            vm.newTag = new Tag();
        }
    }

    private void Button_Clicked(object sender, EventArgs e) {

    }

    private void CommingSoon_Clicked(object sender, EventArgs e) {

    }

    private void CommingSoonOkBton_Clicked(object sender, EventArgs e) {

    }
}