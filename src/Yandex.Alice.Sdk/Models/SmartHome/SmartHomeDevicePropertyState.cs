namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    [JsonConverter(typeof(SmartHomeDevicePropertyStateConverter))]
    public abstract class SmartHomeDevicePropertyState
    {
        [JsonPropertyName("type")]
        public string Type { get; }

        protected SmartHomeDevicePropertyState(string type)
        {
            Type = type;
        }
    }
}
