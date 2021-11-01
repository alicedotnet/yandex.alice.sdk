namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceCapabilityStateValue<TValue> : SmartHomeDeviceCapabilityStateValue
    {
        [JsonPropertyName("value")]
        public TValue Value { get; set; }
    }
}
