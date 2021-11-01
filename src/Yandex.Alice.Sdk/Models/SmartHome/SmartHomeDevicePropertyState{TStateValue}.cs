namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;

    public abstract class SmartHomeDevicePropertyState<TStateValue> : SmartHomeDevicePropertyState
        where TStateValue : SmartHomeDevicePropertyStateValue
    {
        [JsonPropertyName("state")]
        public TStateValue State { get; set; }

        protected SmartHomeDevicePropertyState(string type)
            : base(type)
        {
        }
    }
}
