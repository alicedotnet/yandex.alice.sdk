namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceMarkupModel
    {
        [JsonPropertyName("dangerous_context")]
        public bool DangerousContext { get; set; }
    }
}
