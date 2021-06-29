namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;
    using Yandex.Alice.Sdk.Models;

    public class MainSecondaryIntentSlots
    {
        [JsonPropertyName("who")]
        [JsonConverter(typeof(AliceEntityModelConverter))]
        public AliceEntityModel WhoSlot { get; set; }
    }
}
