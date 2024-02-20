namespace MauiAppLogin;

public partial class MainPage : ContentPage
{
    private AuthenticationViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new AuthenticationViewModel(Navigation);
        BindingContext = viewModel;

        viewModel.AutoLoginAsync();
    }

    void OnToggled(object sender, ToggledEventArgs e)
    {
        Microsoft.Maui.Controls.Switch switchControl = (Microsoft.Maui.Controls.Switch)sender;
        bool isSwitchToggled = e.Value;
        viewModel.isSwitchToggled = isSwitchToggled;
    }
}
