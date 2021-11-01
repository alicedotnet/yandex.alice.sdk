namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    [JsonConverter(typeof(SmartHomeDeviceColorSettingCapabilityStateValueConverter))]
    public class SmartHomeDeviceColorSettingCapabilityStateValue : SmartHomeDeviceCapabilityStateValue<object>
    {
    }
}
