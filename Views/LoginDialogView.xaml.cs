namespace PhotoOrganizer.Views;

public partial class LoginDialogView : SfPopup {

    public LoginDialogView() {
        InitializeComponent();

        var loginDialogViewModel = IPlatformApplication.Current!.Services.GetRequiredService<LoginDialogViewModel>();

        var messenger = IPlatformApplication.Current!.Services.GetRequiredService<IMessenger>();

        BindingContext = loginDialogViewModel;

        messenger.Register<string>(this, (sender, msg) => {
            if(msg == MessengerKeys.LoginRequested) {
                IsOpen = true;
            }
            if(msg == MessengerKeys.LoginSucceeded) {
                IsOpen = false;
            }
        });
    }


}