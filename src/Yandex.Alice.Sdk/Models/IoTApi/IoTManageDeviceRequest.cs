namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class IoTManageDeviceRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("actions")]
        public List<SmartHomeDeviceCapabilityState> Actions { get; set; }
    }
}
