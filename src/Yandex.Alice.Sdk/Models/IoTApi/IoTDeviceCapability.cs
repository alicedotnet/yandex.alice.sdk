namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    [JsonConverter(typeof(IoTDeviceCapabilityConverter))]
    public abstract class IoTDeviceCapability
    {
        [JsonPropertyName("reportable")]
        public bool Reportable { get; set; }

        [JsonPropertyName("retrievable")]
        public bool Retrievable { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("last_updated")]
        public double LastUpdated { get; set; }
    }
}
