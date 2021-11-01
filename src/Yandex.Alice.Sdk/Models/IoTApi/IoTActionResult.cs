namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;

    public class IoTActionResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
