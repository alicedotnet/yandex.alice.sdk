namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeResponseDevicesActionPayload
    {
        [JsonPropertyName("devices")]
        public List<SmartHomeResponseDevicesActionDevice> Devices { get; set; }
    }
}
