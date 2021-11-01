namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeRequestDevicesQuery
    {
        [JsonPropertyName("devices")]
        public List<SmartHomeRequestDevicesQueryDevice> Devices { get; set; }
    }
}
