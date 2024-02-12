using Firebase.Auth;
using Newtonsoft.Json;

namespace MauiAppLogin.Resources.ViewModels
{
    var email = RegisterViewModel.Email;
    var password = RegisterViewModel.Password;

    internal class RegisterViewModel
    {
        public string webApiKey = " ";

        private INavigation _navigation;



        public Command RegisterUser { get; }

        public RegisterViewModel(INavigation navigation)
        {
            this._navigation = navigation;

            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}
