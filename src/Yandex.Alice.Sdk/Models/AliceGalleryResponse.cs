using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryResponse : AliceGalleryResponse<object, object>
    {
        public AliceGalleryResponse(AliceRequestBase<object, object> request, string text, bool keepSessionState = true)
            : this(request, text, text, keepSessionState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<object, object> request, string text, string tts, bool keepSessionState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<object, object> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : this(request, text, text, buttons, keepSessionState)
        {
        }


        public AliceGalleryResponse(AliceRequestBase<object, object> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : base(request, text, tts, buttons, keepSessionState)
        {
        }    
    }

    public class AliceGalleryResponse<TSession, TUser>
        : AliceResponseBase<AliceGalleryResponseModel, TSession, TUser>
    {
        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, bool keepSessionState = true)
            : this(request, text, text, keepSessionState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, string tts, bool keepSessionState = true)
            : this(request, text, tts, new List<AliceButtonModel>(), keepSessionState)
        {
        }

        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : this(request, text, text, buttons, keepSessionState)
        {
        }


        public AliceGalleryResponse(AliceRequestBase<TSession, TUser> request, string text, string tts, List<AliceButtonModel> buttons, bool keepSessionState = true)
            : base(request, text, tts, buttons, keepSessionState)
        {
        }
    }
}
