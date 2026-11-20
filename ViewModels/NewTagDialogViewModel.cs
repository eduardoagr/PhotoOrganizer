namespace PhotoOrganizer.ViewModels;

public partial class NewTagDialogViewModel(IMessenger messenger) : ObservableObject {

    [ObservableProperty]
    public partial Tag? newTag { get; set; } = new Tag();

    [RelayCommand]
    private void SaveTag() {
        messenger.Send("CloseNewTagDialog");
    }
}
