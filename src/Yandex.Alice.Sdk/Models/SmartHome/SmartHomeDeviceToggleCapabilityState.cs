namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceToggleCapabilityState : SmartHomeDeviceCapabilityState<SmartHomeDeviceToggleCapabilityStateValue>
    {
        public SmartHomeDeviceToggleCapabilityState()
            : base(SmartHomeConstants.Devices.Capabilities.Toggle)
        {
        }
    }
}
