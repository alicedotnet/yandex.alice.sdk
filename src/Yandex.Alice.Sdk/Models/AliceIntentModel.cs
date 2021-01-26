using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceIntentModel
        : AliceIntentModel<object>
    {

    }

    public class AliceIntentModel<TSlots>
    {
        [JsonPropertyName("slots")]
        public TSlots Slots { get; set; }
    }
}
