//using MauiAppLogin.Resources.ViewModels;
using AndroidX.Lifecycle;

namespace MauiAppLogin;

public partial class MainPage : ContentPage
{
    private AuthenticationViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        var viewModel = new AuthenticationViewModel(Navigation);
        BindingContext = viewModel;

        // Call the AutoLogin method from the ViewModel
        //viewModel.AutoLoginAsync();
    }

    async void OnToggled(object sender, ToggledEventArgs e)
    {
        // 'sender' is the Switch that triggered the event
        Switch switchControl = (Switch)sender;

        // 'e.Value' is the new value of the Switch (true if on, false if off)
        bool isSwitchToggled = e.Value;

        if (isSwitchToggled == true)
        {
            await viewModel.HandleSwitchToggledAsync();
        }
    }
}
