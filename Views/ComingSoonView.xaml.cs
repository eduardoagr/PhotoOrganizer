namespace PhotoOrganizer.Views;

public partial class ComingSoonView : ContentPage {
    public ComingSoonView() {
        InitializeComponent();
    }

    private void CommingSoonOkBton_Clicked(object sender, EventArgs e) {

        Application.Current.Quit();
    }
}