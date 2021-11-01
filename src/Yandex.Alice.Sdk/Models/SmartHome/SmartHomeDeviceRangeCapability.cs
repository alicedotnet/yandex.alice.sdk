namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceRangeCapability
        : SmartHomeDeviceCapability<SmartHomeDeviceRangeCapabilityParameters>
    {
        public SmartHomeDeviceRangeCapability()
            : base(SmartHomeConstants.Devices.Capabilities.Range)
        {
        }
    }
}
