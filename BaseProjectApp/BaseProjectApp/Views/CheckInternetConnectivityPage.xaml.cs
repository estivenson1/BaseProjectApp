using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseProjectApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckInternetConnectivityPage : ContentPage
    {
        public CheckInternetConnectivityPage()
        {
            InitializeComponent();
        }


        private async void btnConnectivityPlugin_Clicked(object sender, EventArgs e)
        {
            var connectivity = CrossConnectivity.Current;
            if (!connectivity.IsConnected)
            {
                await DisplayAlert("Conectividad", "Verifique su conexión a internet P1", "Aceptar");
                return;
            }

            var reachable = await connectivity.IsRemoteReachable("motzcod.es");

            if(!reachable)
            {
                await DisplayAlert("Conectividad", "Verifique su conexión a internet P2", "Aceptar");
                return;
            }

            await DisplayAlert("Conectividad", "Conexión a internet Ok", "Aceptar");
        }
    }
}