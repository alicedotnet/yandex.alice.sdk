namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceOnOffCapability : SmartHomeDeviceCapability<SmartHomeDeviceOnOffCapabilityParameters>
    {
        public SmartHomeDeviceOnOffCapability()
            : base(SmartHomeConstants.Devices.Capabilities.OnOff)
        {
        }
    }
}
