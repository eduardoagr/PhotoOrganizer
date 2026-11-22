using CommunityToolkit.Maui.Core;

namespace PhotoOrganizer.Interfaces;

public interface IShellService {

    Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel);

    Task DisplayAlertAsync(string title, string message, string cancel);

    Task ShowToastAsync(string toastMessage, ToastDuration duration, int fontsize);

    Task GoToAsync(ShellNavigationState pageName, bool amitation = true);

    Task GoToAsync(ShellNavigationState pageName, Dictionary<string, object> parameters);
}
