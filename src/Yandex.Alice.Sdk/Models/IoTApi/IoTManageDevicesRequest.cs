namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class IoTManageDevicesRequest
    {
        [JsonPropertyName("devices")]
        public List<IoTManageDeviceRequest> Devices { get; set; }
    }
}
