using Firebase.Auth;
using Firebase.Auth.Providers;
using static Android.Net.Wifi.Hotspot2.Pps.Credential;



public class AuthenticationViewModel
{
    FirebaseAuthConfig config = new FirebaseAuthConfig
    {
        ApiKey = "AIzaSyCL9tNQqeYhtuW3Xc0xl492qriAhcsjcus",
        AuthDomain = "test-724e3.firebaseapp.com",
        Providers = new FirebaseAuthProvider[]
        {
    new EmailProvider()
    },

    };

    private INavigation _navigation;



    public Command LoginBtn { get; }
    public Command RegisterBtn { get; }
    public Command RegisterUser { get; }



    public string RegEmail { get; set; }
    public string RegPassword { get; set; }

    public string LoginEmail { get; set; }
    public string LoginPassword { get; set; }



    public AuthenticationViewModel(INavigation navigation)
    {
        this._navigation = navigation;

        LoginBtn = new Command(LoginBtnTappedAsync);
        RegisterBtn = new Command(RegisterBtnTappedAsync);
        RegisterUser = new Command(RegisterUserTappedAsync);
    }


    private async void LoginBtnTappedAsync(object obj)
    {
        var client = new FirebaseAuthClient(config);

        try
        {
            var loginEmail = LoginEmail;
            var loginPassword = LoginPassword;
            var userCredential = await client.SignInWithEmailAndPasswordAsync(LoginEmail, LoginPassword);

            await Application.Current.MainPage.DisplayAlert("Success", "You are being logged in.", "OK");
            await this._navigation.PushAsync(new MauiAppLogin.Dashboard());
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }

    }


    private async void RegisterBtnTappedAsync(object obj)
    {
        await this._navigation.PushAsync(new MauiAppLogin.RegisterPage());
    }

    public async void RegisterUserTappedAsync(object obj)
    {
        var client = new FirebaseAuthClient(config);
        try
        {
            var regEmail = RegEmail;
            var regPassword = RegPassword;


            var userCredential = await client.CreateUserWithEmailAndPasswordAsync(regEmail, regPassword);
            await Application.Current.MainPage.DisplayAlert("Success", "ACCOUNT CREATED.", "OK");
        }
        catch (Exception ex)
        {

            await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }
    }


    public async Task AutoLoginAsync()
    {
        var client = new FirebaseAuthClient(config);
        var email = await SecureStorage.GetAsync("email");
        var password = await SecureStorage.GetAsync("password");

        if (email != null && password != null) {
            var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);
            await this._navigation.PushAsync(new MauiAppLogin.Dashboard());
        }
    }



    public async Task HandleSwitchToggledAsync()
    {
        var client = new FirebaseAuthClient(config);
        var email = await SecureStorage.GetAsync("email");
        var password = await SecureStorage.GetAsync("password");

        var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);
        if (userCredential != null)
        {
            await SecureStorage.SetAsync("email", email);
            await SecureStorage.SetAsync("password", password);
        }
    }


}