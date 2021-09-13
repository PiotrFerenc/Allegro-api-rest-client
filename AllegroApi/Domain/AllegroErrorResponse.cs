using Newtonsoft.Json;

namespace AllegroApi.Domain
{
    public class AllegroErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; } 
    }
}