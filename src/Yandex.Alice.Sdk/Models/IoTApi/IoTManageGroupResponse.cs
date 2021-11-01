namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class IoTManageGroupResponse : IoTResponseBase
    {
        [JsonPropertyName("devices")]
        public List<IoTManageDeviceResponse> Devices { get; set; }
    }
}
