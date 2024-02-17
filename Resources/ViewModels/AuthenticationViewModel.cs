using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Diagnostics;



public class AuthenticationViewModel
{
    FirebaseAuthConfig config = new FirebaseAuthConfig
    {
        ApiKey = "",
        AuthDomain = "",
        Providers = new FirebaseAuthProvider[]
        {
    new EmailProvider()
    },

    };

    private INavigation _navigation;

    public bool isSwitchToggled { get; set; }

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
        var loginEmail = LoginEmail;
        var loginPassword = LoginPassword;
        bool switchStatus = isSwitchToggled;
        //Trace.WriteLine(" S W I T C H     S T A T U S " + switchStatus);

        if (switchStatus) {
            await SecureStorage.SetAsync("loginEmail", loginEmail);
            await SecureStorage.SetAsync("loginPassword", loginPassword);
        }
        else { 
            SecureStorage.RemoveAll();
        }

        try
        {
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
            Trace.WriteLine($"ERROR: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }
    }


    public async Task AutoLoginAsync()
    {
        var client = new FirebaseAuthClient(config);
        var loginEmail = await SecureStorage.GetAsync("loginEmail");
        var loginPassword = await SecureStorage.GetAsync("loginPassword");

        if (!string.IsNullOrEmpty(loginEmail) && !string.IsNullOrEmpty(loginPassword))
        {
            var userCredential = await client.SignInWithEmailAndPasswordAsync(loginEmail, loginPassword);
            await this._navigation.PushAsync(new MauiAppLogin.Dashboard());
        }
        else
        {
            Trace.WriteLine("Autologin failed.");
        }
    }

    
}