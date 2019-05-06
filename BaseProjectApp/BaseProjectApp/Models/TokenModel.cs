namespace BaseProjectApp.Models
{
    using Newtonsoft.Json;

    public class TokenModel
    {
        //[JsonProperty(PropertyName = "Latitud")]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("departamento")]
        public string Departamento { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
