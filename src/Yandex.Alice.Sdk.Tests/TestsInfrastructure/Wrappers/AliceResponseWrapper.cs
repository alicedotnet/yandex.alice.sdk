using System;
using System.Collections.Generic;
using System.Text;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers
{
    public class AliceResponseWrapper : AliceResponse
    {
        //empty constructor to test deserialization
        public AliceResponseWrapper()
            : this(new AliceRequest(), string.Empty, null)
        {

        }

        public AliceResponseWrapper(AliceRequest request, string text, List<AliceButtonModel> buttons) 
            : base(request, text, buttons)
        {
        }
    }
}
