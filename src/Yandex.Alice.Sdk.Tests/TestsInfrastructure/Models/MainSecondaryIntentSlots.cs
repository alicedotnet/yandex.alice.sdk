using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models
{
    public class MainSecondaryIntentSlots
    {
        [JsonPropertyName("who")]
        [JsonConverter(typeof(AliceEntityModelConverter))]
        public AliceEntityModel WhoSlot { get; set; }
    }
}
