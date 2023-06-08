namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceOnOffCapabilityParameters : ISmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("split")]
        public bool Split { get; set; }
    }
}
