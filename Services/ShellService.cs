using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace PhotoOrganizer.Services;

public class ShellService : IShellService {
    public async Task DisplayAlertAsync(string title, string message, string cancel) {
        await Shell.Current.DisplayAlertAsync(title, message, cancel);
    }

    public async Task GoToAsync(ShellNavigationState pageName, bool amitation = true) {
        await Shell.Current.GoToAsync(pageName);
    }

    public Task GoToAsync(ShellNavigationState pageName, Dictionary<string, object> parameters) {

        return Shell.Current.GoToAsync(pageName, parameters);
    }

    public async Task ShowToastAsync(string toastMessage, ToastDuration duration, int fontsize) {

        CancellationTokenSource cancellationTokenSource = new();

        await Toast.Make(toastMessage, ToastDuration.Short, 16)
            .Show(cancellationTokenSource.Token);
    }
}
