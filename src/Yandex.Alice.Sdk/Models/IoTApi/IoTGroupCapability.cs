namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Converters;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [JsonConverter(typeof(IoTGroupCapabilityConverter))]
    public abstract class IoTGroupCapability
    {
        [JsonPropertyName("retrievable")]
        public bool Retrievable { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
