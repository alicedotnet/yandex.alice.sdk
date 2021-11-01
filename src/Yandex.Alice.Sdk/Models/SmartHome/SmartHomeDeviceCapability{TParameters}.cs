namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public abstract class SmartHomeDeviceCapability<TParameters> : SmartHomeDeviceCapability
        where TParameters : SmartHomeDeviceCapabilityParameters
    {
        [JsonPropertyName("parameters")]
        public TParameters Parameters { get; set; }

        protected SmartHomeDeviceCapability(string type)
            : base(type)
        {
        }
    }
}
