namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class AliceRequestModelBase
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(AliceRequestTypeConverter))]
        public AliceRequestType Type { get; set; }

        [JsonPropertyName("original_utterance")]
        public string OriginalUtterance { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }

        [JsonPropertyName("markup")]
        public AliceMarkupModel Markup { get; set; }
    }
}
