namespace Yandex.Alice.Sdk.Converters
{
    using System;
    using System.Collections.Generic;
    using Yandex.Alice.Sdk.Models.IoTApi;

    public class IoTGroupCapabilityConverter : SmartHomeTypeConverter<IoTGroupCapability>
    {
        protected override IReadOnlyDictionary<string, Type> EntityNameTypeMap => new Dictionary<string, Type>
        {
            { SmartHomeConstants.Devices.Capabilities.OnOff, typeof(IoTGroupOnOffCapability) },
            { SmartHomeConstants.Devices.Capabilities.ColorSetting, typeof(IoTGroupColorSettingCapability) },
            { SmartHomeConstants.Devices.Capabilities.Mode, typeof(IoTGroupModeCapability) },
            { SmartHomeConstants.Devices.Capabilities.Range, typeof(IoTGroupRangeCapability) },
            { SmartHomeConstants.Devices.Capabilities.Toggle, typeof(IoTGroupToggleCapability) },
        };

        protected override string GetErrorMessage(string type)
        {
            return $"Unknown group capability type \"{type}\"";
        }
    }
}
