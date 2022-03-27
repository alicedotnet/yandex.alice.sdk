namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeResponseDevicesActionCapability
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("state")]
        public SmartHomeResponseDevicesActionCapabilityState State { get; set; }
    }
}
