using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLogin.Resources.ViewModels
{
    internal class LoginViewModel
    {
        public LoginViewModel(INavigation navigation) 
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
        }

        private INavigation _navigation;

        public Command RegisterBtn { get; }

        private void RegisterBtnTappedAsync(object obj)
        {
            this._navigation.PushAsync(new RegisterPage());
        }
    }
}
