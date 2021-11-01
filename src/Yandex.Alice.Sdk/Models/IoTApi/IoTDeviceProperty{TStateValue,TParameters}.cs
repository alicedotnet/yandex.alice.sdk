namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public abstract class IoTDeviceProperty<TStateValue, TParameters> : IoTDeviceProperty
        where TStateValue : SmartHomeDevicePropertyStateValue
        where TParameters : SmartHomeDevicePropertyParameters
    {
        [JsonPropertyName("state")]
        public TStateValue State { get; set; }

        [JsonPropertyName("parameters")]
        public TParameters Parameters { get; set; }
    }
}
