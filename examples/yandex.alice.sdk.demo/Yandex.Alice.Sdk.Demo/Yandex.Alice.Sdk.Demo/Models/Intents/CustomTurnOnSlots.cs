using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Converters;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Demo.Models.Intents
{
    public class CustomTurnOnSlots
    {
        [JsonPropertyName("what")]
        [JsonConverter(typeof(AliceEntityModelConverter))]
        public AliceEntityModel What { get; set; }

        [JsonPropertyName("where")]
        [JsonConverter(typeof(AliceEntityModelConverter))]
        public AliceEntityModel Where { get; set; }
    }
}
