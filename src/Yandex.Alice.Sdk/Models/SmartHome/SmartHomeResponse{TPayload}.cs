namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public abstract class SmartHomeResponse<TPayload> : SmartHomeResponse
    {
        [JsonPropertyName("payload")]
        public TPayload Payload { get; set; }
    }
}
