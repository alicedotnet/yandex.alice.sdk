namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceEntityGeoModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public AliceEntityGeoValueModel Value { get; set; }
    }
}
