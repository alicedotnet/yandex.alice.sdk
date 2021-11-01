namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;

    public class IoTManageDeviceResponseCapability
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("state")]
        public IoTManageDeviceResponseCapabilityState State { get; set; }
    }
}
