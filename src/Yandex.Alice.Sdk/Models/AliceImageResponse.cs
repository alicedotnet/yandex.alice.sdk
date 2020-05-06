using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceImageResponse : AliceResponseBase<AliceImageResponseModel>
    {
        public AliceImageResponse()
        {

        }

        public AliceImageResponse(AliceRequest request) 
            : base(request)
        {
        }
    }
}
