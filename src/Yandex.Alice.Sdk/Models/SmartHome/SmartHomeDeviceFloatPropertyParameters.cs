namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceFloatPropertyParameters : SmartHomeDevicePropertyParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}
