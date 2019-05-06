using Newtonsoft.Json;

namespace BaseProjectApp.Models
{
    public class AsistenteModel
    {
        [JsonProperty("departamento")]
        public string Departamento { get; set; }

        [JsonProperty("ciudadOrigen")]
        public string CiudadOrigen { get; set; }

        [JsonProperty("totalRegistrados")]
        public int TotalRegistrados { get; set; }

        [JsonProperty("totalManillasPorEntregar")]
        public int TotalManillasPorEntregar { get; set; }

        [JsonProperty("totalManillasEntregadas")]
        public int TotalManillasEntregadas { get; set; }
    }
}
