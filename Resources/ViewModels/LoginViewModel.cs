using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
//using MauiAppLogin.Resources.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ThreadNetwork;
//using ThreadNetwork;


public class LoginViewModel{

    FirebaseAuthConfig config = new FirebaseAuthConfig
    {
        ApiKey = "",
        AuthDomain = "",
        Providers = new FirebaseAuthProvider[]

        {
        new EmailProvider()
    },

    };

    public Command LoginBtn { get; }
    public Command RegisterBtn { get; }


    //public Command ForgotPwdBtn { get; }



    public string Email { get; set; }
    public string Password { get; set; }
    //public string ForgotPwdEmail { get; set; }

    private INavigation _navigation;

    public LoginViewModel(INavigation navigation)
    {
        this._navigation = navigation;

        LoginBtn = new Command(LoginBtnTappedAsync);
        RegisterBtn = new Command(RegisterBtnTappedAsync);
        //ForgotPwdBtn = new Command(ForgotPwdBtnTappedAsync);
    }

    private async void LoginBtnTappedAsync(object obj)
    {
        var client = new FirebaseAuthClient(config);
        
        try
        {
            var email = Email;
            var password = Password;

            var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);

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

    //TODO Add autologin with SecureStorage

    /*
    private async void ForgotPwdBtnTappedAsync(object obj)
    {
        await this._navigation.PushAsync(new MauiAppLogin.ForgotPwdPage());

        var client = new FirebaseAuthClient(config);
        try
        {
            var forgotPwdEmail = ForgotPwdEmail;

            var userCredential = await client.
            await Application.Current.MainPage.DisplayAlert("Success", "You are being logged in.", "OK");
            await this._navigation.PushAsync(new MauiAppLogin.Dashboard());
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
        }
    }*/
    
    
    
    
}