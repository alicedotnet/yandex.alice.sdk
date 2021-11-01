namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceInfo
    {
        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("hw_version")]
        public string HwVersion { get; set; }

        [JsonPropertyName("sw_version")]
        public string SwVersion { get; set; }
    }
}
