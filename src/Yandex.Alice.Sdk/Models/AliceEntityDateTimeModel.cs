namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceEntityDateTimeModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public AliceEntityDateTimeValueModel Value { get; set; }
    }
}
