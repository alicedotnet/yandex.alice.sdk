namespace Yandex.Alice.Sdk.Demo.Models.Intents
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models;

    public class CustomIntents
    {
        [JsonPropertyName("turn.on")]
        public AliceIntentModel<CustomTurnOnSlots> TurnOn { get; set; }
    }
}
