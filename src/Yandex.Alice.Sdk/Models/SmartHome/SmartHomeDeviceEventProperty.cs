namespace Yandex.Alice.Sdk.Models.SmartHome
{
    public class SmartHomeDeviceEventProperty : SmartHomeDeviceProperty<SmartHomeDeviceEventPropertyParameters>
    {
        public SmartHomeDeviceEventProperty()
            : base(SmartHomeConstants.Devices.Properties.Event)
        {
        }
    }
}
