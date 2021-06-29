namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceEntityNumberModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
}
