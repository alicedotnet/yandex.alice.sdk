namespace Yandex.Alice.Sdk.Demo.Models.Intents
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;
    using Yandex.Alice.Sdk.Models;

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
