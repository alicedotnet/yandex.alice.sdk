namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class SmartHomeDeviceCapabilityStateConverter : SmartHomeTypeConverter<SmartHomeDeviceCapabilityState>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>
        {
            { SmartHomeConstants.Devices.Capabilities.OnOff, typeof(SmartHomeDeviceOnOffCapabilityState) },
            { SmartHomeConstants.Devices.Capabilities.ColorSetting, typeof(SmartHomeDeviceColorSettingCapabilityState) },
            { SmartHomeConstants.Devices.Capabilities.Mode, typeof(SmartHomeDeviceModeCapabilityState) },
            { SmartHomeConstants.Devices.Capabilities.Range, typeof(SmartHomeDeviceRangeCapabilityState) },
            { SmartHomeConstants.Devices.Capabilities.Toggle, typeof(SmartHomeDeviceToggleCapabilityState) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown device capability state type \"{type}\"";
        }
    }
}
