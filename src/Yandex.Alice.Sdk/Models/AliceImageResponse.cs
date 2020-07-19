using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceImageResponse : AliceImageResponse<object, object>
    {
        public AliceImageResponse(AliceRequestBase request, string text)
            : this(request, text, text, null)
        {
        }

        public AliceImageResponse(AliceRequestBase request, string text, string tts)
            : this(request, text, tts, null)
        {
        }

        public AliceImageResponse(AliceRequestBase request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }


        public AliceImageResponse(AliceRequestBase request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request, text, tts, buttons)
        {
        }
    }

    public class AliceImageResponse<TSession, TUSer> 
        : AliceResponseBase<AliceImageResponseModel, TSession, TUSer>
    {
        public AliceImageResponse(AliceRequestBase request, string text)
            : this(request, text, text, null)
        {
        }

        public AliceImageResponse(AliceRequestBase request, string text, string tts)
            : this(request, text, tts, null)
        {
        }

        public AliceImageResponse(AliceRequestBase request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }


        public AliceImageResponse(AliceRequestBase request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request, text, tts, buttons)
        {
        }
    }
}
