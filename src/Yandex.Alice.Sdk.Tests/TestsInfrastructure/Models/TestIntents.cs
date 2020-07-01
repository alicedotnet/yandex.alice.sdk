using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models
{
    public class TestIntents
    {
        [JsonPropertyName("main")]
        public AliceIntentModel<MainIntentSlots> Main { get; set; }

        [JsonPropertyName("main_secondary")]
        public AliceIntentModel<MainSecondaryIntentSlots> MainSecondary { get; set; }
    }
}
