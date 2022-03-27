namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeResponseDevicesActionCapabilityState
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("action_result")]
        public SmartHomeActionResult ActionResult { get; set; }
    }
}
