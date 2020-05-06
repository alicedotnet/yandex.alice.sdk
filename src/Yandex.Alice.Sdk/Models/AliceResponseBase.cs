using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public abstract class AliceResponseBase<T> : AliceResponseBase
    {
        [JsonPropertyName("response")]
        public T Response { get; set; }

        protected AliceResponseBase()
        {

        }

        protected AliceResponseBase(AliceRequest request)
            :base(request)
        {

        }
    }

    public abstract class AliceResponseBase
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("session_state")]
        public object SessionState { get; set; }
        [JsonPropertyName("user_state_update")]
        public object UserStateUpdate { get; set; }

        protected AliceResponseBase()
        {

        }

        protected AliceResponseBase(AliceRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Version = request.Version;
        }
    }
}
