namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers;

using System.Collections.Generic;
using Yandex.Alice.Sdk.Models;

public class AliceResponseWrapper : AliceResponse
{
    // empty constructor to test deserialization
    public AliceResponseWrapper()
        : this(new AliceRequest { State = new AliceStateModel<object, object>() }, string.Empty, null)
    {
    }

    public AliceResponseWrapper(AliceRequest request, string text, List<AliceButtonModel> buttons)
        : base(request, text, buttons)
    {
    }
}