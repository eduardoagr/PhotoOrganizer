using CommunityToolkit.Mvvm.Messaging;

using Syncfusion.Maui.Popup;

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

    }

    private void RootPopup_Closed(object sender, EventArgs e) {
        Messenger?.Send("Close");
    }
}