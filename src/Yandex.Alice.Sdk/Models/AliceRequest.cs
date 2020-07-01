using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceRequest : AliceRequest<object>
    {

    }

    public class AliceRequest<TIntents>
    {
        [JsonPropertyName("meta")]
        public AliceMetaModel Meta { get; set; }

        [JsonPropertyName("request")]
        public AliceRequestModel<TIntents> Request { get; set; }

        [JsonPropertyName("session")]
        public AliceSessionModel Session { get; set; }

        [JsonPropertyName("state")]
        public AliceStateModel State { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
