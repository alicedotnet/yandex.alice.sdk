namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public abstract class SmartHomeResponse
    {
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
    }
}
