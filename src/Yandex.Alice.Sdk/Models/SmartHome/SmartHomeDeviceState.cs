namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeDeviceState
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("capabilities")]
        public List<SmartHomeDeviceCapabilityState> Capabilities { get; set; }

        [JsonPropertyName("properties")]
        public List<SmartHomeDevicePropertyState> Properties { get; set; }

        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
    }
}
