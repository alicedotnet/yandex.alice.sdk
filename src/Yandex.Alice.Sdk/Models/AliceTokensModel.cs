namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceTokensModel
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }
    }
}
