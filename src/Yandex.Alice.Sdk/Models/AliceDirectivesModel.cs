namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceDirectivesModel
    {
        [JsonPropertyName("request_geolocation")]
        public object RequestGeolocation { get; set; }

        public void SetRequestGeolocation()
        {
            RequestGeolocation = new object();
        }
    }
}
