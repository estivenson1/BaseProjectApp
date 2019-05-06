namespace BaseProjectApp.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using BaseProjectApp.Models;
    using BaseProjectApp.Services;

    public class AsistentesRegistradosViewModel
    {
        #region Attributes
        ApiService api;
        #endregion


        #region Properties
        public ObservableCollection<AsistenteModel> LstAsistente { get; set; }
        #endregion


        #region Constructors
        public AsistentesRegistradosViewModel()
        {
            api = MainViewModel.GetInstance().api;

            LoadAsistentes();
        }
        #endregion


        #region Methods	
        private async void LoadAsistentes()
        {
            var asistentes = await api.GetAsistentes();
            LstAsistente = new ObservableCollection<AsistenteModel>(asistentes);
        }
        #endregion


        #region Commands

        #endregion
    }
}
