namespace PhotoOrganizer;

public partial class App : Application {
    public App() {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState) {

        Page page = DeviceInfo.Idiom == DeviceIdiom.Desktop
       ? new ComingSoonView()
       : new AppShell();

        return new Window(page);
    }
}