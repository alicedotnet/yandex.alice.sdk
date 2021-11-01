namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    [JsonConverter(typeof(SmartHomeDevicePropertyConverter))]
    public abstract class SmartHomeDeviceProperty
    {
        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonPropertyName("retrievable")]
        public bool Retrievable { get; set; }

        [JsonPropertyName("reportable")]
        public bool Reportable { get; set; }

        protected SmartHomeDeviceProperty(string type)
        {
            Type = type;
        }
    }
}
