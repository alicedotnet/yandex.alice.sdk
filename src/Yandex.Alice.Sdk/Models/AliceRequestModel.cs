namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class AliceRequestModel
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }

        [JsonPropertyName("original_utterance")]
        public string OriginalUtterance { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }

        [JsonPropertyName("markup")]
        public AliceMarkupModel Markup { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(AliceRequestTypeConverter))]
        public AliceRequestType Type { get; set; }

        [JsonPropertyName("purchase_request_id")]
        public string PurchaseRequestId { get; set; }

        [JsonPropertyName("purchase_token")]
        public string PurchaseToken { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("purchase_timestamp")]
        public long PurchaseTimestamp { get; set; }

        [JsonPropertyName("purchase_payload")]
        public object PurchasePayload { get; set; }

        [JsonPropertyName("signed_data")]
        public string SignedData { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }
    }
}
