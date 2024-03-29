﻿namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeRequestDevicesQueryDevice
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("custom_data")]
        public object CustomData { get; set; }
    }
}
