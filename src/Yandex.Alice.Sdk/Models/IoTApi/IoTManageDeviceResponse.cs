namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class IoTManageDeviceResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("capabilities")]
        public List<IoTManageDeviceResponseCapability> Capabilities { get; set; }
    }
}
