namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class SmartHomeDevicePropertyStateConverter : SmartHomeTypeConverter<SmartHomeDevicePropertyState>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>()
        {
            { SmartHomeConstants.Devices.Properties.Float, typeof(SmartHomeDeviceFloatPropertyState) },
            { SmartHomeConstants.Devices.Properties.Event, typeof(SmartHomeDeviceEventPropertyState) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown device property state type \"{type}\"";
        }
    }
}
