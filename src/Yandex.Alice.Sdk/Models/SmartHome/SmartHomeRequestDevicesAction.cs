namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeRequestDevicesAction
    {
        [JsonPropertyName("payload")]
        public SmartHomeRequestDevicesActionPayload Payload { get; set; }
    }
}
