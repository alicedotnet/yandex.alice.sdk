namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Models.SmartHome;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class IoTManageGroupRequest
    {
        [JsonPropertyName("actions")]
        public List<SmartHomeDeviceCapabilityState> Actions { get; set; }
    }
}
