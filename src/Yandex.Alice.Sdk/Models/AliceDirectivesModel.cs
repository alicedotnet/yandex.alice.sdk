namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceDirectivesModel
    {
        [JsonPropertyName("request_geolocation")]
        public AliceRequestGeolocationDirective RequestGeolocation { get; set; }

        [JsonPropertyName("start_purchase")]
        public AliceStartPurchaseDirective StartPurchase { get; set; }

        [JsonPropertyName("confirm_purchase")]
        public AliceConfirmPurchaseDirective ConfirmPurchase { get; set; }
    }
}
