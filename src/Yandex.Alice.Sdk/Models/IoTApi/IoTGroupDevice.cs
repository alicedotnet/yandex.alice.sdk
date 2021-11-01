namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;

    public class IoTGroupDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
