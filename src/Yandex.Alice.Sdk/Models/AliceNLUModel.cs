namespace Yandex.Alice.Sdk.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Converters;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceNluModel<TIntents>
    {
        [JsonPropertyName("tokens")]
        public IEnumerable<string> Tokens { get; set; }

        [JsonPropertyName("entities")]
        [JsonConverter(typeof(AliceEntityModelEnumerableConverter))]
        public IEnumerable<AliceEntityModel> Entities { get; set; }

        [JsonPropertyName("intents")]
        public TIntents Intents { get; set; }
    }
}
