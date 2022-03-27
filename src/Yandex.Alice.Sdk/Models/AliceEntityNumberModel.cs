namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceEntityNumberModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
}
