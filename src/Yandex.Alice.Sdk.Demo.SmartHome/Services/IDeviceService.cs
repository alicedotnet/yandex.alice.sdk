namespace Yandex.Alice.Sdk.Demo.SmartHome.Services;

using Yandex.Alice.Sdk.Demo.SmartHome.Models;
using Yandex.Alice.Sdk.Models.SmartHome;

public interface IDeviceService
{
    SmartHomeResponseDevices GetDevicesResponse(SmartHomeRequestHeaders requestHeaders);

    SmartHomeResponseDevicesQuery GetDevicesQueryResponse(SmartHomeRequestHeaders requestHeaders, SmartHomeRequestDevicesQuery payload);

    SmartHomeResponseDevicesAction ChangeDeviceState(SmartHomeRequestHeaders requestHeaders, SmartHomeRequestDevicesAction payload);
}