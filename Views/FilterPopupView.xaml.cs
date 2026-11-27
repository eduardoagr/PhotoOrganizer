namespace PhotoOrganizer.Views;

public partial class FilterPopupView : SfPopup {

    private readonly IMessenger Messenger;
    
    public FilterPopupView(IMessenger messenger, FilterPopupViewModel filterPopupViewModel) {
        InitializeComponent();

        Messenger = messenger;

        BindingContext = filterPopupViewModel;
    }

}