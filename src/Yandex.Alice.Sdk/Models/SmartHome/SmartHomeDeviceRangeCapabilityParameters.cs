namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceRangeCapabilityParameters : SmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("random_access")]
        public bool RandomAccess { get; set; }

        [JsonPropertyName("range")]
        public SmartHomeRange Range { get; set; }
    }
}
