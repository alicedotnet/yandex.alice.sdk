namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeDeviceMode
    {
        [JsonPropertyName("value")]
        public string Value { get; }

        public SmartHomeDeviceMode(string value)
        {
            Value = value;
        }
    }
}
