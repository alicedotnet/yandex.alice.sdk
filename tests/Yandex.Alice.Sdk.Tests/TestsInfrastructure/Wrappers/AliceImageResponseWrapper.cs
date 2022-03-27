namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers;

using Yandex.Alice.Sdk.Models;

public class AliceImageResponseWrapper : AliceImageResponse
{
    public AliceImageResponseWrapper()
        : base(new AliceRequest { State = new AliceStateModel<object, object>() }, "sample")
    {
    }
}