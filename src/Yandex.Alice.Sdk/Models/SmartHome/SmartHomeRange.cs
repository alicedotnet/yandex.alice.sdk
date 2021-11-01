namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeRange
    {
        [JsonPropertyName("min")]
        public float Min { get; set; }

        [JsonPropertyName("max")]
        public float Max { get; set; }

        [JsonPropertyName("precision")]
        public float Precision { get; set; }
    }
}
