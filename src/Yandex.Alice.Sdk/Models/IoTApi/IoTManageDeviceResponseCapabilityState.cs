namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class IoTManageDeviceResponseCapabilityState
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("action_result")]
        public IoTActionResult ActionResult { get; set; }
    }
}
