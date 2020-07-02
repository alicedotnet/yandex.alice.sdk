using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Demo.Models.Intents
{
    public class CustomIntents
    {
        [JsonPropertyName("turn.on")]
        public AliceIntentModel<CustomTurnOnSlots> TurnOn { get; set; }
    }
}
