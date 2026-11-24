using CommunityToolkit.Mvvm.Messaging.Messages;

namespace PhotoOrganizer.ViewModels;

public partial class NewTagDialogViewModel(IMessenger messenger, ITagService tagService, IShellService shellService) : ObservableObject {

    [ObservableProperty]
    public partial Tag? newTag { get; set; } = new Tag();

    [RelayCommand]
    private async Task SaveTagAsync() {

        if(newTag is null ||
            string.IsNullOrWhiteSpace(newTag.Name) ||
            string.IsNullOrWhiteSpace(newTag.Color)) {

            await shellService.DisplayAlertAsync("", "Please fill in all fields.", "OK");
            return;
        }

        var newTagCreated = await tagService.CreateTagAsync(newTag.Name, newTag.Color);

        messenger.Send(new ValueChangedMessage<Tag>(newTagCreated));

        messenger.Send(MessengerKeys.CloseNewTagDialog);
    }

    [RelayCommand]
    private async Task Cancel() {
        messenger.Send(MessengerKeys.CloseNewTagDialog);
    }
}
