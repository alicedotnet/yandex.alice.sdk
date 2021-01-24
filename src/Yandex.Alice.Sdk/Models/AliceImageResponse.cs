using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceImageResponse : AliceImageResponse<object, object>
    {
        public AliceImageResponse(AliceRequestBase<object, object> request, string text, bool keepSessionState = true)
            : this(request, text, text, keepSessionState)
        {
        }

        public AliceImageResponse(AliceRequestBase<object, object> request, string text, string tts, bool keepSessionState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState)
        {
        }

        public AliceImageResponse(AliceRequestBase<object, object> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : this(request, text, text, buttons, keepSessionState)
        {
        }


        public AliceImageResponse(AliceRequestBase<object, object> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : base(request, text, tts, buttons, keepSessionState)
        {
        }
    }

    public class AliceImageResponse<TSession, TUSer> 
        : AliceResponseBase<AliceImageResponseModel, TSession, TUSer>
    {
        public AliceImageResponse(AliceRequestBase<TSession, TUSer> request, string text, bool keepSessionState = true)
            : this(request, text, text, keepSessionState)
        {
        }

        public AliceImageResponse(AliceRequestBase<TSession, TUSer> request, string text, string tts, bool keepSessionState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState)
        {
        }

        public AliceImageResponse(AliceRequestBase<TSession, TUSer> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : this(request, text, text, buttons, keepSessionState)
        {
        }


        public AliceImageResponse(AliceRequestBase<TSession, TUSer> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : base(request, text, tts, buttons, keepSessionState)
        {
        }
    }
}
