namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers;

using Yandex.Alice.Sdk.Models;

public class AliceGalleryResponseWrapper : AliceGalleryResponse
{
    public AliceGalleryResponseWrapper()
        : base(new AliceRequest { State = new AliceStateModel<object, object>() }, string.Empty, string.Empty, null)
    {
    }
}