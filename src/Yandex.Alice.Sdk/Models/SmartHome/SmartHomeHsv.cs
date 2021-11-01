namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public class SmartHomeHsv
    {
        [JsonPropertyName("h")]
        public int H { get; set; }

        [JsonPropertyName("s")]
        public int S { get; set; }

        [JsonPropertyName("v")]
        public int V { get; set; }
    }
}
