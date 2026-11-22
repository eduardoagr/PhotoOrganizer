namespace PhotoOrganizer.Views;

public partial class UserAccountDialog : SfPopup {
    public UserAccountDialog() {
        InitializeComponent();

        var viewModel = IPlatformApplication.Current!.Services.GetRequiredService<CreatePhotoViewModel>();

        var messenger = IPlatformApplication.Current!.Services.GetRequiredService<IMessenger>();

        BindingContext = viewModel;

        messenger.Register<string>(this, (sender, msg) => {
            if(msg == MessengerKeys.ShowAccountDialog) {
                IsOpen = true;
            }
        });
    }
}