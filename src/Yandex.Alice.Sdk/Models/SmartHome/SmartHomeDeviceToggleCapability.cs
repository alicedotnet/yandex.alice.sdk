namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceToggleCapability : SmartHomeDeviceCapability<SmartHomeDeviceToggleCapabilityParameters>
    {
        public SmartHomeDeviceToggleCapability()
            : base(SmartHomeConstants.Devices.Capabilities.Toggle)
        {
        }
    }
}
