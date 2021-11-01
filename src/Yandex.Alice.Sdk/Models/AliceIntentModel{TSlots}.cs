namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceIntentModel<TSlots>
    {
        [JsonPropertyName("slots")]
        public TSlots Slots { get; set; }
    }
}
