namespace BaseProjectApp.ViewModels
{
    using Helpers;
    using Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel
    {

        #region Attributes
        private static MainViewModel instance;
        #endregion


        #region Properties
        public ObservableCollection<MenuItemGeneric> MenuMaster { get; set; }
        public LoginViewModel LoginVM { get; set; }
        #endregion


        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.LoadMenuMaster();
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion


        #region Methods	
        private void LoadMenuMaster()
        {
            var menus = new List<MenuItemGeneric>
                {                    
                    new MenuItemGeneric {Icon = "ic_person",PageName = "RegistroEventoPage",Title = "Registro"},
                    new MenuItemGeneric {Icon = "ic_person",PageName = "EntregaManillaPage",Title = "Manillas"},
                    new MenuItemGeneric {Icon = "ic_phonelink_setup",PageName = "AsistentesRegistradosPage",Title = "Reporte "},
                    new MenuItemGeneric {Icon = "ic_info",PageName = "AboutPage",Title = "About"},
                    new MenuItemGeneric {Icon = "ic_exit_to_app",PageName = "LoginPage",Title = "Cerrar sesión"}
                };

            this.MenuMaster = new ObservableCollection<MenuItemGeneric>(
                menus.Select(m => new MenuItemGeneric { Icon = m.Icon, PageName = m.PageName, Title = m.Title }).ToList());
        }

        #endregion


        #region Commands
        //public ICommand SelectMenuMasterCommand => new RelayCommand<object>(this.SelectMenuMaster);  
        public ICommand SelectMenuMasterCommand { get { return new RelayCommand<object>(this.SelectMenuMaster); } }
        private async void SelectMenuMaster(object parameter)
        {
            App.MdiMasterDetail.IsPresented = false;
            var menuMaster = parameter as MenuItemGeneric;
            switch (menuMaster.PageName)
            {
                case "RegistroEventoPage":
                    await App.Navigator.PushAsync(new RegistroEventoPage());
                    break;
                case "EntregaManillaPage":
                    await App.Navigator.PushAsync(new EntregaManillaPage());
                    break;
                case "AsistentesRegistradosPage":
                    //mainViewModel.Profile = new ProfileViewModel();
                    await App.Navigator.PushAsync(new AsistentesRegistradosPage());
                    break;
                case "AboutPage":
                    //mainViewModel.Profile = new ProfileViewModel();
                    await App.Navigator.PushAsync(new AboutPage());
                    break;
                default:
                    //Settings.User = string.Empty;
                    //Settings.IsRemember = false;
                    //Settings.Token = string.Empty;
                    //Settings.UserEmail = string.Empty;
                    //Settings.UserPassword = string.Empty;

                    MainViewModel.GetInstance().LoginVM = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }

        public ICommand MenuOpcionesCommand { get { return new RelayCommand<MenuItemGeneric>(this.MenuOpcionesCom); } }

        private async void MenuOpcionesCom(MenuItemGeneric parameter)
        {
            switch (parameter.PageName)
            {
                case "RegistroEventoPage":
                    await App.Navigator.PushAsync(new RegistroEventoPage());
                    break;
                case "EntregaManillaPage":
                    await App.Navigator.PushAsync(new EntregaManillaPage());
                    break;
                case "AsistentesRegistradosPage":
                    //mainViewModel.Profile = new ProfileViewModel();
                    await App.Navigator.PushAsync(new AsistentesRegistradosPage());
                    break;
                case "AboutPage":
                    //mainViewModel.Profile = new ProfileViewModel();
                    await App.Navigator.PushAsync(new AboutPage());
                    break;
                default:
                    MainViewModel.GetInstance().LoginVM = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;

            }
        }
        #endregion

    }
}


#region Attributes

#endregion


#region Properties

#endregion


#region Constructors

#endregion


#region Methods	

#endregion


#region Commands

#endregion