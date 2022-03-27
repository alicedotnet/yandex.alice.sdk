namespace Yandex.Alice.Sdk.Demo.Models.Intents;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Yandex.Alice.Sdk.Models;

[UsedImplicitly]
public class CustomIntents
{
    public CustomIntents(AliceIntentModel<CustomTurnOnSlots> turnOn)
    {
        TurnOn = turnOn;
    }

    [JsonPropertyName("turn.on")]
    public AliceIntentModel<CustomTurnOnSlots> TurnOn { get; }
}