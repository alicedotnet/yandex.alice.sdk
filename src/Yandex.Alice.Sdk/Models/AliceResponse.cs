using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceResponse : AliceResponse<object, object>
    {
        public AliceResponse(AliceRequestBase<object, object> request, string text, bool keepSessionState = true)
            : this(request, text, text, keepSessionState)
        {
        }

        public AliceResponse(AliceRequestBase<object, object> request, string text, string tts, bool keepSessionState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState)
        {
        }

        public AliceResponse(AliceRequestBase<object, object> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : this(request, text, text, buttons, keepSessionState)
        {
        }


        public AliceResponse(AliceRequestBase<object, object> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : base(request, text, tts, buttons, keepSessionState)
        {
        }
    }

    public class AliceResponse<TSession, TUser> 
       : AliceResponseBase<AliceResponseModel, TSession, TUser>
    {
        public AliceResponse(AliceRequestBase<TSession, TUser> request, string text, bool keepSessionState = true)
            : this(request, text, text, keepSessionState)
        {
        }

        public AliceResponse(AliceRequestBase<TSession, TUser> request, string text, string tts, bool keepSessionState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState)
        {
        }

        public AliceResponse(AliceRequestBase<TSession, TUser> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : this(request, text, text, buttons, keepSessionState)
        {
        }


        public AliceResponse(AliceRequestBase<TSession, TUser> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : base(request, text, tts, buttons, keepSessionState)
        {            
        }
    }
}
