namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Models.SmartHome;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsCallbackStateDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("capabilities")]
        public List<SmartHomeDeviceCapabilityState> Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public List<SmartHomeDevicePropertyState> Properties { get; set; }
    }
}
