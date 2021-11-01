namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceColorSettingCapability : SmartHomeDeviceCapability<SmartHomeDeviceColorSettingCapabilityParameters>
    {
        public SmartHomeDeviceColorSettingCapability()
            : base(SmartHomeConstants.Devices.Capabilities.ColorSetting)
        {
        }
    }
}
