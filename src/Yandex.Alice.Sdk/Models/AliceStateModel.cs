using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Helpers;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceStateModel<TSession, TUser>
    {
        [JsonPropertyName("session")]
        public TSession Session { get; set; }

        [JsonPropertyName("user")]
        public TUser User { get; set; }

        [JsonPropertyName("application")]
        public TUser Application { get; set; }

        [JsonIgnore]
        public TUser UserOrApplication
        {
            get
            {
                if (User != null)
                {
                    return User;
                }
                return Application;
            }
        }

        public T TryGetSession<T>()
        {
            return AliceHelper.JsonElementToObject<T>(Session);
        }

        public T TryGetUser<T>()
        {
            return AliceHelper.JsonElementToObject<T>(User);
        }
    }
}
