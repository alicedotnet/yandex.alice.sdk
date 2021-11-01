namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class SmartHomeDevicePropertyConverter : SmartHomeTypeConverter<SmartHomeDeviceProperty>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>()
        {
            { SmartHomeConstants.Devices.Properties.Float, typeof(SmartHomeDeviceFloatProperty) },
            { SmartHomeConstants.Devices.Properties.Event, typeof(SmartHomeDeviceEventProperty) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown device property type \"{type}\"";
        }
    }
}
