namespace PhotoOrganizer.ViewModels;

public partial class FilterPopupViewModel(ITagStore tagStore, IMessenger messenger) : ObservableObject {

    public ObservableCollection<Tag> Tags => tagStore.Tags;

    [RelayCommand]
    void ApplyBton() {

    }

    [RelayCommand]
    void CancelBton() {
        messenger.Send(MessengerKeys.ClosePopup);
    }

}

