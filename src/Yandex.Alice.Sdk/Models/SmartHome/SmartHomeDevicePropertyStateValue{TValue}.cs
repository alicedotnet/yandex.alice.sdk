namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDevicePropertyStateValue<TValue> : SmartHomeDevicePropertyStateValue
    {
        [JsonPropertyName("value")]
        public TValue Value { get; set; }
    }
}
