namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeRequestDevicesActionPayload
    {
        [JsonPropertyName("devices")]
        public List<SmartHomeRequestDevicesActionDevice> Devices { get; set; }
    }
}
