namespace BaseProjectApp.ViewModels
{
    using BaseProjectApp.Models;
    using BaseProjectApp.Services;
    using BaseProjectApp.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;


    public class LoginViewModel: BaseViewModel
    {

        #region Attributes
        ApiService api;
        #endregion


        #region Properties
        public string Usuario { get; set; }

        public string Password { get; set; }

        private bool isRunning;
        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }
        #endregion


        #region Constructors
        public LoginViewModel()
        {
            api = MainViewModel.GetInstance().api;
            IsRunning = true;

        }
        #endregion


        #region Methods	

        #endregion


        #region Commands
        public ICommand LoginCommand => new RelayCommand(Login);
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Verificar datos",
                    "Digite usuario",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Verificar datos",
                    "Digite contraseña",
                    "Aceptar");
                return;
            }



            var login = new LoginModel
            {
                Password = this.Password,
                Username = this.Usuario
            };


            var token =  await api.Iniciar(login);
            App.Token = token;    

            //this.IsRunning = true;
            //this.IsEnabled = false;

            //var request = new TokenRequest
            //{
            //    Password = this.Password,
            //    Username = this.Email
            //};

            //var url = Application.Current.Resources["UrlAPI"].ToString();
            //var response = await this.apiService.GetTokenAsync(
            //    url,
            //    "/Account",
            //    "/CreateToken",
            //    request);

            //this.IsRunning = false;
            //this.IsEnabled = true;

            //if (!response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //        Languages.Error,
            //        Languages.LoginError,
            //        Languages.Accept);
            //    return;
            //}

            //var token = (TokenResponse)response.Result;

            //var response2 = await this.apiService.GetUserByEmailAsync(
            //    url,
            //    "/api",
            //    "/Account/GetUserByEmail",
            //    this.Email,
            //    "bearer",
            //    token.Token);

            //var user = (User)response2.Result;

            //mainViewModel.User = user;
            //mainViewModel.Token = token;
            //mainViewModel.UserEmail = this.Email;
            //mainViewModel.UserPassword = this.Password;
            //mainViewModel.Products = new ProductsViewModel();

            //Settings.IsRemember = this.IsRemember;
            //Settings.UserEmail = this.Email;
            //Settings.UserPassword = this.Password;
            //Settings.Token = JsonConvert.SerializeObject(token);
            //Settings.User = JsonConvert.SerializeObject(user);

            if (!string.IsNullOrEmpty(token.Message))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Verificar datos",
                    "Usuario y/o contraseña inválidos",
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            Application.Current.MainPage = new MdiMasterDetailPage();
        }
        #endregion
    }
}
