namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeRequestDevicesActionDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("custom_data")]
        public object CustomData { get; set; }

        [JsonPropertyName("capabilities")]
        public List<SmartHomeDeviceCapabilityState> Capabilities { get; set; }
    }
}
