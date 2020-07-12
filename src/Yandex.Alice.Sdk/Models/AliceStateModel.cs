using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Helpers;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceStateModel
    {
        [JsonPropertyName("session")]
        public object Session { get; set; }

        [JsonPropertyName("user")]
        public object User { get; set; }
    }

    public static class AliceStateModelExtensions
    {
        public static T TryGetSession<T>(this AliceStateModel aliceStateModel)
        {
            return AliceHelper.JsonElementToObject<T>(aliceStateModel?.Session);
        }

        public static T TryGetUser<T>(this AliceStateModel aliceStateModel)
        {
            return AliceHelper.JsonElementToObject<T>(aliceStateModel?.User);
        }
    }
}
