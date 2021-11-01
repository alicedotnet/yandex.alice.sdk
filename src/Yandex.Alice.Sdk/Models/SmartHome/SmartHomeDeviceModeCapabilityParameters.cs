namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceModeCapabilityParameters : SmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("modes")]
        public List<SmartHomeDeviceMode> Modes { get; set; }
    }
}
