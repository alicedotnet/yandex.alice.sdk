namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public abstract class DialogsCallbackRequest<TPayload>
    {
        [JsonPropertyName("ts")]
        public double Timestamp { get; set; }

        [JsonPropertyName("payload")]
        public TPayload Payload { get; set; }
    }
}
