namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceIntentModel<TSlots>
    {
        [JsonPropertyName("slots")]
        public TSlots Slots { get; set; }
    }
}
