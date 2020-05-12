using System;
using System.Collections.Generic;
using System.Text;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Wrappers
{
    public class AliceGalleryResponseWrapper : AliceGalleryResponse
    {
        public AliceGalleryResponseWrapper()
            : base(new AliceRequest(), string.Empty, string.Empty, null)
        {
        }
    }
}
