namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeEvent
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public SmartHomeEvent(string value)
        {
            Value = value;
        }
    }
}
