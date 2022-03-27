namespace Yandex.Alice.Sdk.Demo.SmartHome.Models;

using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

public class SmartHomeRequestHeaders
{
    [FromHeader(Name = "X-Request-Id")]
    public string RequestId
    {
        get;
        [UsedImplicitly]
        set;
    }
}