namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class IoTManageDevicesResponse : IoTResponseBase
    {
        [JsonPropertyName("devices")]
        public List<IoTManageDeviceResponse> Devices { get; set; }
    }
}
