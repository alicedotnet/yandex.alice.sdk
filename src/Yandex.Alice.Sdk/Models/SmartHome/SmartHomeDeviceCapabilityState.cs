namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    [JsonConverter(typeof(SmartHomeDeviceCapabilityStateConverter))]
    public abstract class SmartHomeDeviceCapabilityState
    {
        [JsonPropertyName("type")]
        public string Type { get; }

        protected SmartHomeDeviceCapabilityState(string type)
        {
            Type = type;
        }
    }
}
