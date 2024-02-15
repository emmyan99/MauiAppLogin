using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Newtonsoft.Json;
using System.Diagnostics;
//using ThreadNetwork;


public class RegisterViewModel{

    FirebaseAuthConfig config = new FirebaseAuthConfig
    {
        ApiKey = "",
        AuthDomain = "",
        Providers = new FirebaseAuthProvider[]
        {
        new EmailProvider()
    },
        
    };


    public Command RegisterUser { get; }
    public string Email { get; set; }
    public string Password { get; set; }

    private INavigation _navigation;

    public RegisterViewModel(INavigation navigation)
    {
        this._navigation = navigation;

        RegisterUser = new Command(RegisterUserTappedAsync);
    }


    public async void RegisterUserTappedAsync(object obj)
    {
        var client = new FirebaseAuthClient(config);
        try
        {
            var email = Email;
            var password = Password;



            var userCredential = await client.CreateUserWithEmailAndPasswordAsync(email, password);
            await Application.Current.MainPage.DisplayAlert("Success", "ACCOUNT CREATED.", "OK");
        }
        catch (Exception ex)
        {
            // For debugging
            //Trace.WriteLine($"Error: {ex}");
           
            await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }
    }


}













