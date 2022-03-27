namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceEntityStringModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
