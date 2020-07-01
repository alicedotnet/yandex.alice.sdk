using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceResponse : AliceResponseBase<AliceResponseModel>
    {
        public AliceResponse(AliceRequestBase request, string text)
            : this(request, text, text, null)
        {
        }

        public AliceResponse(AliceRequestBase request, string text, string tts)
            : this(request, text, tts, null)
        {
        }

        public AliceResponse(AliceRequestBase request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }


        public AliceResponse(AliceRequestBase request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request, text, tts, buttons)
        {            
        }
    }
}
