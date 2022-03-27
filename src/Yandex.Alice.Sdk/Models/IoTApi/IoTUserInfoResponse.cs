namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class IoTUserInfoResponse : IoTResponseBase
    {
        [JsonPropertyName("rooms")]
        public List<IoTRoom> Rooms { get; set; }

        [JsonPropertyName("groups")]
        public List<IoTGroup> Groups { get; set; }

        [JsonPropertyName("devices")]
        public List<IoTDevice> Devices { get; set; }

        [JsonPropertyName("scenarios")]
        public List<IoTScenario> Scenarios { get; set; }

        [JsonPropertyName("households")]
        public List<IoTHousehold> Households { get; set; }
    }
}
