namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Models.SmartHome;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public abstract class IoTDeviceCapability<TStateValue, TParameters> : IoTDeviceCapability
        where TStateValue : SmartHomeDeviceCapabilityStateValue
        where TParameters : ISmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("state")]
        public TStateValue State { get; set; }

        [JsonPropertyName("parameters")]
        public TParameters Parameters { get; set; }
    }
}
