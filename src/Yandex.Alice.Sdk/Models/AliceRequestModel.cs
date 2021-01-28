using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceRequestModel<TIntents>
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

        public T GetPayload<T>()
        {
            if(Payload is JsonElement payloadJsonElement)
            {
                string text = payloadJsonElement.GetRawText();
                return JsonSerializer.Deserialize<T>(text);
            }
            return default;
        }

        [JsonPropertyName("markup")]
        public AliceMarkupModel Markup { get; set; }

        [JsonPropertyName("nlu")]
        public AliceNLUModel<TIntents> Nlu { get; set; }
    }
}
