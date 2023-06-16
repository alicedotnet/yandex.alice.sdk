namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceColorSettingCapabilityParameters : ISmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("color_model")]
        public string ColorModel { get; set; }

        [JsonPropertyName("temperature_k")]
        public SmartHomeTemperatureK TemperatureK { get; set; }

        [JsonPropertyName("color_scene")]
        public SmartHomeDeviceColorScene ColorScene { get; set; }
    }
}
