namespace Yandex.Alice.Sdk.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceStartPurchaseDirective
    {
        [JsonPropertyName("purchase_request_id")]
        public string PurchaseRequestId { get; set; }

        [JsonPropertyName("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }

        [JsonPropertyName("merchant_key")]
        public string MerchantKey { get; set; }

        [JsonPropertyName("test_payment")]
        public bool TestPayment { get; set; }

        [JsonPropertyName("products")]
        public List<AliceProduct> Products { get; set; }
    }
}
