namespace PhotoOrganizer.ViewModels;

public partial class NewTagDialogViewModel(IMessenger messenger, ITagService tagService) : ObservableObject {

    [ObservableProperty]
    public partial Tag? newTag { get; set; } = new Tag();

    [RelayCommand]
    private async Task SaveTagAsync() {
        
        if(newTag is null || string.IsNullOrEmpty(newTag.Name) || string.IsNullOrEmpty(newTag.Color))
            return;

        await tagService.CreateTagAsync(newTag.Name, newTag.Color);

        messenger.Send(MessengerKeys.CloseNewTagDialog);
    }
}
