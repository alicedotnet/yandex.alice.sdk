namespace Yandex.Alice.Sdk.Demo.Models;

using Yandex.Alice.Sdk.Demo.Models.Intents;
using Yandex.Alice.Sdk.Demo.Models.Session;
using Yandex.Alice.Sdk.Models;

public class DemoAliceRequest : AliceRequest<CustomIntents, CustomSessionState, object>
{
}