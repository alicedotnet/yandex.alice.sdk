namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SmartHomeResponseDevicesQueryPayload
    {
        [JsonPropertyName("devices")]
        public List<SmartHomeDeviceState> Devices { get; set; }
    }
}
