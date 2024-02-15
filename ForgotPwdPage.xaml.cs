namespace MauiAppLogin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPwdPage : ContentPage
    {
        public ForgotPwdPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}