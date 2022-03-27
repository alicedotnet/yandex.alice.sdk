namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class IoTActionResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
