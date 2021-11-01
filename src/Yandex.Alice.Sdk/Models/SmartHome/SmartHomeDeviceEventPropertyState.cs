namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceEventPropertyState : SmartHomeDevicePropertyState<SmartHomeDeviceEventPropertyStateValue>
    {
        public SmartHomeDeviceEventPropertyState()
            : base(SmartHomeConstants.Devices.Properties.Event)
        {
        }
    }
}
