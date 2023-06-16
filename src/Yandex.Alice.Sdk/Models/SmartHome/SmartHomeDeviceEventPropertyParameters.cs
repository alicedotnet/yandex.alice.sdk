namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceEventPropertyParameters : ISmartHomeDevicePropertyParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("events")]
        public List<SmartHomeEvent> Events { get; set; }
    }
}
