namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class IoTDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("aliases")]
        public List<string> Aliases { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("external_id")]
        public string ExternalId { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }

        [JsonPropertyName("household_id")]
        public string HouseholdId { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("groups")]
        public List<string> Groups { get; set; }

        [JsonPropertyName("capabilities")]
        public List<IoTDeviceCapability> Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public List<IoTDeviceProperty> Properties { get; set; }
    }
}
