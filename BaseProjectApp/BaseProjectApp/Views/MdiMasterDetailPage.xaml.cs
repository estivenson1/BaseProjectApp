namespace BaseProjectApp.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MdiMasterDetailPage : MasterDetailPage
    {
		public MdiMasterDetailPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = this.Navigator;
            App.MdiMasterDetail = this;
        }
    }
}