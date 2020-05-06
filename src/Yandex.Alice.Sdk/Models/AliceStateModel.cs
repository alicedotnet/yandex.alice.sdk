using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceStateModel
    {
        [JsonPropertyName("session")]
        public object Session { get; set; }

        [JsonPropertyName("user")]
        public object User { get; set; }
    }
}
