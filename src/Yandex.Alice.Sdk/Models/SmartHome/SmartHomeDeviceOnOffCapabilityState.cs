namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceOnOffCapabilityState : SmartHomeDeviceCapabilityState<SmartHomeDeviceOnOffCapabilityStateValue>
    {
        public SmartHomeDeviceOnOffCapabilityState()
            : base(SmartHomeConstants.Devices.Capabilities.OnOff)
        {
        }
    }
}
