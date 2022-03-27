namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceEntityFioModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public AliceEntityFioValueModel Value { get; set; }
    }
}
