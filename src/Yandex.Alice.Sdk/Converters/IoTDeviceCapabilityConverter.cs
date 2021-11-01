namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.IoTApi;

    public class IoTDeviceCapabilityConverter : SmartHomeTypeConverter<IoTDeviceCapability>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>()
        {
            { SmartHomeConstants.Devices.Capabilities.OnOff, typeof(IoTDeviceOnOffCapability) },
            { SmartHomeConstants.Devices.Capabilities.ColorSetting, typeof(IoTDeviceColorSettingCapability) },
            { SmartHomeConstants.Devices.Capabilities.Mode, typeof(IoTDeviceModeCapability) },
            { SmartHomeConstants.Devices.Capabilities.Range, typeof(IoTDeviceRangeCapability) },
            { SmartHomeConstants.Devices.Capabilities.Toggle, typeof(IoTDeviceToggleCapability) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown IoT device capability type \"{type}\"";
        }
    }
}
