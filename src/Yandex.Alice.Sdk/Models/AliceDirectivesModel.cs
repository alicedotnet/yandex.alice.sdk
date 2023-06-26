namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceDirectivesModel
    {
        [JsonPropertyName("request_geolocation")]
        public AliceRequestGeolocationDirective RequestGeolocation { get; set; }

        [JsonPropertyName("start_purchase")]
        public AliceStartPurchaseDirective StartPurchase { get; set; }

        [JsonPropertyName("confirm_purchase")]
        public AliceConfirmPurchaseDirective ConfirmPurchase { get; set; }

        [JsonPropertyName("start_account_linking")]
        public AliceStartAccountLinkingDirective StartAccountLinking { get; set; }
    }
}
