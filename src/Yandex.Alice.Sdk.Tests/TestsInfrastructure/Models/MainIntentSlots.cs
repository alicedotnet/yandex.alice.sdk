using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models
{
    public class MainIntentSlots
    {
        [JsonPropertyName("what")]
        [JsonConverter(typeof(AliceEntityModelConverter))]
        public AliceEntityModel WhatSlot { get; set; }

        [JsonPropertyName("where")]
        [JsonConverter(typeof(AliceEntityModelConverter))]
        public AliceEntityModel WhereSlot { get; set; }
    }
}
