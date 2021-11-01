namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public abstract class SmartHomeDeviceCapabilityState<TStateValue> : SmartHomeDeviceCapabilityState
        where TStateValue : SmartHomeDeviceCapabilityStateValue
    {
        [JsonPropertyName("state")]
        public TStateValue State { get; set; }

        protected SmartHomeDeviceCapabilityState(string type)
            : base(type)
        {
        }
    }
}
