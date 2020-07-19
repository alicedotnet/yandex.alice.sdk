using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Helpers;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceStateModel : AliceStateModel<object, object>
    {

    }

    public class AliceStateModel<TSession, TUser>
    {
        [JsonPropertyName("session")]
        public TSession Session { get; set; }

        [JsonPropertyName("user")]
        public TUser User { get; set; }
    }

    public static class AliceStateModelExtensions
    {
        public static T TryGetSession<T>(this AliceStateModel<object, object> aliceStateModel)
        {
            return AliceHelper.JsonElementToObject<T>(aliceStateModel?.Session);
        }

        public static T TryGetUser<T>(this AliceStateModel<object, object> aliceStateModel)
        {
            return AliceHelper.JsonElementToObject<T>(aliceStateModel?.User);
        }
    }
}
