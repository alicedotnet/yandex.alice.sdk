using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceRequest<TIntents> : AliceRequestBase
    {
        [JsonPropertyName("request")]
        public AliceRequestModel<TIntents> Request { get; set; }
    }

    public class AliceRequest : AliceRequestBase
    {
        [JsonPropertyName("request")]
        public AliceRequestModel<object> Request { get; set; }
    }

    public abstract class AliceRequestBase
    {
        [JsonPropertyName("meta")]
        public AliceMetaModel Meta { get; set; }

        [JsonPropertyName("session")]
        public AliceSessionModel Session { get; set; }

        [JsonPropertyName("state")]
        public AliceStateModel State { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
