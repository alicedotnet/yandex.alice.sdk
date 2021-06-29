using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Demo.Models.Intents;
using Yandex.Alice.Sdk.Demo.Models.Session;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Demo.Models
{
    public class DemoAliceRequest : AliceRequest<CustomIntents, CustomSessionState, object>
    {
    }
}
