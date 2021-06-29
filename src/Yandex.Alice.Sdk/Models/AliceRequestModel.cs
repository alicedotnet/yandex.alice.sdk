namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class AliceRequestModel<TIntents> : AliceRequestModelBase
    {
        [JsonPropertyName("nlu")]
        public AliceNLUModel<TIntents> Nlu { get; set; }
    }

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
