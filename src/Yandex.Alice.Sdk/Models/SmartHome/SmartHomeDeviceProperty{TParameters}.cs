namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public abstract class SmartHomeDeviceProperty<TParameters> : SmartHomeDeviceProperty
        where TParameters : ISmartHomeDevicePropertyParameters
    {
        [JsonPropertyName("parameters")]
        public TParameters Parameters { get; set; }

        protected SmartHomeDeviceProperty(string type)
            : base(type)
        {
        }
    }
}
