using Microsoft.Extensions.Logging;

using PhotoBrowsers;

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
            fonts.AddFont("MaterialIconsRound-Regular.otf", "MaterialIconsRound");
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
        builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
        builder.Services.AddSingleton<ICreateExcel, CreateExcel>();
        builder.Services.AddSingleton<IShellService, ShellService>();
        builder.Services.AddSingleton<IDeviceIdService, DeviceIdService>();
        builder.Services.AddSingleton<IBucketsService, BucketsService>();

        builder.Services.AddSingleton<IDataServices, DatabaseService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<ISupabaseDataService, SupabaseDataService>();
        builder.Services.AddSingleton<ITagService, TagService>();

        builder.Services.AddSingleton<CreatePhotoViewModel>();
        builder.Services.AddTransient<CreatePhotoView>();

        builder.Services.AddSingleton<GalleryView>();
        builder.Services.AddTransient<GalleryViewModel>();

        builder.Services.AddTransient<NewTagDialogViewModel>();
        builder.Services.AddTransient<NewTagDialogView>();

        builder.Services.AddSingleton(new Client("https://mbbvwgyhmwjpcnhcdgqv.supabase.co", Keys.SUPABASE_KEY));

        return builder.Build();
    }
}
