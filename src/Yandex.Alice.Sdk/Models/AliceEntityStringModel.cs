namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceEntityStringModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
