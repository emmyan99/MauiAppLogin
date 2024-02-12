Using Firebase.Auth;
Using Newtonsoft.Json;

namespace MauiAppLogin.Resources.ViewModels
{
    internal class RegisterViewModel
    {
        public string webApiKey = "AIzaSyCL9tNQqeYhtuW3Xc0xl492qriAhcsjcus";

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
