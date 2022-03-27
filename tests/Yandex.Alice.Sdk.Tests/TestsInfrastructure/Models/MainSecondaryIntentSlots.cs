namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Yandex.Alice.Sdk.Converters;
using Yandex.Alice.Sdk.Models;

[UsedImplicitly]
public class MainSecondaryIntentSlots
{
    public MainSecondaryIntentSlots(AliceEntityModel whoSlot)
    {
        WhoSlot = whoSlot;
    }

    [JsonPropertyName("who")]
    [JsonConverter(typeof(AliceEntityModelConverter))]
    public AliceEntityModel WhoSlot { get; }
}