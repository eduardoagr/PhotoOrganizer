using Microsoft.Extensions.Logging;

using PhotoBrowsers;

using PhotoOrganizer.Helpers;

using Shiny;

using Supabase;

using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;

namespace PhotoOrganizer;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        SyncfusionLicenseProvider.RegisterLicense(Keys.SYNCFUSION_KEY);
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts => {
            fonts.AddFont("MaterialIconsRound-Regular.otf", alias: "MaterialIconsRound");
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).ConfigureSyncfusionCore().UseMauiCommunityToolkit()
            .UseShinyControls().ConfigurePhotoBrowser()
            .UseShinyCamera(media => {
                media.CompressionQuality = 85;
                media.MaxDimension = 2048;
                media.OutputFormat = MediaImageFormat.Jpeg;
            });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton(MediaPicker.Default);
        builder.Services.AddSingleton(Geolocation.Default);
        builder.Services.AddSingleton(Geocoding.Default);
        builder.Services.AddSingleton(Share.Default);
        builder.Services.AddSingleton(SecureStorage.Default);
        builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
        builder.Services.AddSingleton<ICreateExcel, CreateExcel>();
        builder.Services.AddSingleton<IShellService, ShellService>();
        builder.Services.AddSingleton<IBucketsService, BucketsService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<ITagService, TagService>();
        builder.Services.AddSingleton<ITagStore, TagStore>();
        builder.Services.AddSingleton<ISupabaseDataService, SupabaseDataService>();


        builder.Services.AddSingleton<CreatePhotoViewModel>();
        builder.Services.AddSingleton<CreatePhotoView>();

        builder.Services.AddSingleton<GalleryView>();
        builder.Services.AddTransient<GalleryViewModel>();

        builder.Services.AddTransient<NewTagDialogViewModel>();
        builder.Services.AddTransient<NewTagDialogView>();

        builder.Services.AddTransient<FilterPopupView>();
        builder.Services.AddTransient<FilterPopupViewModel>();

        builder.Services.AddTransient<LoginDialogViewModel>();
        builder.Services.AddTransient<LoginDialogView>();

        builder.Services.AddSingleton(provider => {
            var client = new Client(
                "https://mbbvwgyhmwjpcnhcdgqv.supabase.co",
                Keys.SUPABASE_KEY);

            client.Auth.SetPersistence(new SupabaseSessionHandler(SecureStorage.Default));

            return client;
        });

        return builder.Build();
    }
}
