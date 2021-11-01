namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class IoTGroupResponse : IoTResponseBase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("aliases")]
        public List<string> Aliases { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("devices")]
        public List<IoTGroupDevice> Devices { get; set; }

        [JsonPropertyName("capabilities")]
        public List<IoTGroupCapability> Capabilities { get; set; }
    }
}
