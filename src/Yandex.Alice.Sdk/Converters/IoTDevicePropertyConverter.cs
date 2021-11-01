namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.IoTApi;

    public class IoTDevicePropertyConverter : SmartHomeTypeConverter<IoTDeviceProperty>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>()
        {
            { SmartHomeConstants.Devices.Properties.Float, typeof(IoTDeviceFloatProperty) },
            { SmartHomeConstants.Devices.Properties.Event, typeof(IoTDeviceEventProperty) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown IoT device property type \"{type}\"";
        }
    }
}
