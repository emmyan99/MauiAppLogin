using MauiAppLogin.Resources.ViewModels;
namespace MauiAppLogin;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    } 

}
