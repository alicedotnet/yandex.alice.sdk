namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeDeviceRangeCapabilityParameters : ISmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("random_access")]
        public bool RandomAccess { get; set; }

        [JsonPropertyName("range")]
        public SmartHomeRange Range { get; set; }
    }
}
