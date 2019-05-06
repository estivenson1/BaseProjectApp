using BaseProjectApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaseProjectApp.Services
{
   
    public class ApiService
    {
        #region Attributes

        #endregion


        #region Properties

        #endregion


        #region Constructors
        public ApiService()
        {

        }
        #endregion


        #region Methods	
        public async Task<TokenModel> Iniciar (LoginModel login)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(AppConfig.ApiHost);
                    var url = AppConfig.ApiHost + AppConfig.AppNameAuth+ AppConfig.POST_LOGIN;

                    HttpResponseMessage response = new HttpResponseMessage();

                    var request = JsonConvert.SerializeObject(login);
                    StringContent sc = new StringContent(request, Encoding.UTF8, "application/json");
                    response = await httpClient.PostAsync(url, sc);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        TokenModel token = JsonConvert.DeserializeObject<TokenModel>(result);
                        return token;
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        TokenModel token = JsonConvert.DeserializeObject<TokenModel>(result);
                        return token;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<AsistenteModel>> GetAsistentes()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(AppConfig.ApiHost);
                    var url = AppConfig.ApiHost + AppConfig.AppNameAsistente + AppConfig.GET_REPORTE;
                    
                    httpClient.DefaultRequestHeaders.Add("Authorization", App.Token.Token);

                    HttpResponseMessage response = new HttpResponseMessage();

                    response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                       List<AsistenteModel> token = JsonConvert.DeserializeObject<List<AsistenteModel>>(result);
                        return token;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
