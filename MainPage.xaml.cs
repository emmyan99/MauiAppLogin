//using MauiAppLogin.Resources.ViewModels;

using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace MauiAppLogin;

public partial class MainPage : ContentPage
{
    private AuthenticationViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new AuthenticationViewModel(Navigation);
        BindingContext = viewModel;

        // Call the AutoLogin method from the ViewModel
        viewModel.AutoLoginAsync();
    }

    void OnToggled(object sender, ToggledEventArgs e)
    {
        // 'sender' is the Switch that triggered the event
        Microsoft.Maui.Controls.Switch switchControl = (Microsoft.Maui.Controls.Switch)sender;
        // 'e.Value' is the new value of the Switch (true if on, false if off)
        bool isSwitchToggled = e.Value;
        viewModel.isSwitchToggled = isSwitchToggled;

    }



}
