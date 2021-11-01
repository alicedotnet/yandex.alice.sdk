namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceToggleCapabilityParameters : SmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }
    }
}
