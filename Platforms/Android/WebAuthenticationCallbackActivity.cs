using Android.App;
using Android.Content;
using Android.Content.PM;

namespace PhotoOrganizer.Platforms.Android;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(
    [Intent.ActionView],
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "photoorganizer",
    DataHost = "login-callback")]
public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity {
}