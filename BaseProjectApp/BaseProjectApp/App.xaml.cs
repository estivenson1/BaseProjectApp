using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BaseProjectApp
{
    using ViewModels;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }

        public static MdiMasterDetailPage MdiMasterDetail { get; internal set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new MdiMasterDetailPage();
            MainViewModel.GetInstance().LoginVM = new LoginViewModel();
            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
