namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class SmartHomeDeviceCapabilityConverter : SmartHomeTypeConverter<SmartHomeDeviceCapability>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>()
        {
            { SmartHomeConstants.Devices.Capabilities.OnOff, typeof(SmartHomeDeviceOnOffCapability) },
            { SmartHomeConstants.Devices.Capabilities.ColorSetting, typeof(SmartHomeDeviceColorSettingCapability) },
            { SmartHomeConstants.Devices.Capabilities.Mode, typeof(SmartHomeDeviceModeCapability) },
            { SmartHomeConstants.Devices.Capabilities.Range, typeof(SmartHomeDeviceRangeCapability) },
            { SmartHomeConstants.Devices.Capabilities.Toggle, typeof(SmartHomeDeviceToggleCapability) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown device capability type \"{type}\"";
        }
    }
}
