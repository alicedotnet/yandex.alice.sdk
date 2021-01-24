using System;
using System.Collections.Generic;
using System.Text;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers
{
    public class AliceImageResponseWrapper : AliceImageResponse
    {
        public AliceImageResponseWrapper() 
            : base(new AliceRequest() { State = new AliceStateModel<object, object>() }, "sample")
        {
        }
    }
}
