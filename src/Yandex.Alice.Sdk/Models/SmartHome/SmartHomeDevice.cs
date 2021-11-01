namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("custom_data")]
        public object CustomData { get; set; }

        [JsonPropertyName("capabilities")]
        public List<SmartHomeDeviceCapability> Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public List<SmartHomeDeviceProperty> Properties { get; set; }

        [JsonPropertyName("device_info")]
        public SmartHomeDeviceInfo DeviceInfo { get; set; }
    }
}
