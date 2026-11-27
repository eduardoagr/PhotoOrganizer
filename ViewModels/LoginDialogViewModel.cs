using CommunityToolkit.Mvvm.Messaging.Messages;

namespace PhotoOrganizer.ViewModels;

public partial class LoginDialogViewModel(IAuthService authService, IShellService shellService, IMessenger messenger) : ObservableObject {

    [RelayCommand]
    async Task SignIn(AuthProvider provider) {
        try {
            var profile = await authService.SignInWithProviderAsync(provider);

            if(profile is not null) {

                messenger.Send(new ValueChangedMessage<Profile>(profile));
                messenger.Send(MessengerKeys.LoginSucceeded);
            }


        } catch(TaskCanceledException) {

            // User cancelled Google sign-in.

        } catch(Exception ex) {

            await shellService.DisplayAlertAsync(
                "Authentication error",
                ex.Message,
                "OK");
        }
    }

}
