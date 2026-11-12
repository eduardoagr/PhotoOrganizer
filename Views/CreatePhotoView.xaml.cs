using CommunityToolkit.Mvvm.Messaging;

namespace PhotoOrganizer.Views;

public partial class CreatePhotoView : ContentPage {

    private readonly IMessenger _messenger;

    public CreatePhotoView(CreatePhotoViewModel vm, IMessenger messenger) {
        InitializeComponent();
        BindingContext = vm;
        _messenger = messenger;

        messenger.Register<string>(this, async (recipient, message) => {
            if(message == "Close") {
                TagsCombo.SelectedItem = null;

                if(BindingContext is CreatePhotoViewModel vm) {
                    await vm.InitializaCommand.ExecuteAsync(null);
                }
            }
        });
    }

    private void TagsCombo_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e) {

        if(BindingContext is not CreatePhotoViewModel vm)
            return;

        if(e.AddedItems?.FirstOrDefault() is not Tag tag) {
            return;
        }

        vm.SelectedTag = tag;

        // ID 6 represents the "New Tag" option.
        if(tag.Name == "New tag") {
            vm.CreateNewTag();
            return;
        }
    }
}