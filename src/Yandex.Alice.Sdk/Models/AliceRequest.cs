using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceRequest 
        : AliceRequest<object>
    {
    }

    public class AliceRequest<TIntents> : 
        AliceRequest<TIntents, object, object>
    {
    }

    public class AliceRequest<TIntents, TSession, TUser> 
        : AliceRequestStateBase<TSession, TUser>
    {
        [JsonPropertyName("request")]
        public AliceRequestModel<TIntents> Request { get; set; }
    }

    public abstract class AliceRequestStateBase<TSession, TUser>
        : AliceRequestBase
    {
        [JsonPropertyName("state")]
        public AliceStateModel<TSession, TUser> State { get; set; }
    }


    public abstract class AliceRequestBase
    {
        [JsonPropertyName("meta")]
        public AliceMetaModel Meta { get; set; }

        [JsonPropertyName("session")]
        public AliceSessionModel Session { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
