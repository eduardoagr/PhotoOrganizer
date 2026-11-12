namespace PhotoOrganizer.ViewModels;

public partial class NewTagDialogViewModel(
    IUserService userService,
    ISupabaseDataService supabaseDataService,
    IShellService shellService,
    IMessenger messenger) : ObservableObject {

    [ObservableProperty]
    public partial Tag? newTag { get; set; } = new Tag();

    private readonly IMessenger? _messenger = messenger;

    private readonly IUserService? _userService = userService;

    private readonly ISupabaseDataService? dataService = supabaseDataService;

    private readonly IShellService? _shellService = shellService;
}
