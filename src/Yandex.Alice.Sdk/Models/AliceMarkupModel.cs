namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceMarkupModel
    {
        [JsonPropertyName("dangerous_context")]
        public bool DangerousContext { get; set; }
    }
}
