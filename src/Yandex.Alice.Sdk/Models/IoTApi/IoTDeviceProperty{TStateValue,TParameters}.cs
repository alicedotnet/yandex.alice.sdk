namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Models.SmartHome;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public abstract class IoTDeviceProperty<TStateValue, TParameters> : IoTDeviceProperty
        where TStateValue : SmartHomeDevicePropertyStateValue
        where TParameters : ISmartHomeDevicePropertyParameters
    {
        [JsonPropertyName("state")]
        public TStateValue State { get; set; }

        [JsonPropertyName("parameters")]
        public TParameters Parameters { get; set; }
    }
}
