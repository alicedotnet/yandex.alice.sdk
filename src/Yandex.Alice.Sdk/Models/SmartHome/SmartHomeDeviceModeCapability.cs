namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceModeCapability : SmartHomeDeviceCapability<SmartHomeDeviceModeCapabilityParameters>
    {
        public SmartHomeDeviceModeCapability()
            : base(SmartHomeConstants.Devices.Capabilities.Mode)
        {
        }
    }
}
