namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceInterfacesModel
    {
        [JsonPropertyName("screen")]
        public object Screen { get; set; }

        [JsonPropertyName("payments")]
        public object Payments { get; set; }

        [JsonPropertyName("account_linking")]
        public object AccountLinking { get; set; }

        [JsonPropertyName("geolocation_sharing")]
        public object GeolocationSharing { get; set; }
    }
}
