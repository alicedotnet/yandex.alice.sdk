namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeResponseDevicesActionDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("capabilities")]
        public List<SmartHomeResponseDevicesActionCapability> Capabilities { get; set; }

        [JsonPropertyName("action_result")]
        public SmartHomeActionResult ActionResult { get; set; }
    }
}
