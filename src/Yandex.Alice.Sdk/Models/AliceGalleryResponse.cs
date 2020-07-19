using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryResponse : AliceGalleryResponse<object, object>
    {
        public AliceGalleryResponse(AliceRequestBase request, string text)
            : this(request, text, text, null)
        {
        }

        public AliceGalleryResponse(AliceRequestBase request, string text, string tts)
            : this(request, text, tts, null)
        {
        }

        public AliceGalleryResponse(AliceRequestBase request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }


        public AliceGalleryResponse(AliceRequestBase request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request, text, tts, buttons)
        {
        }    }

    public class AliceGalleryResponse<TSession, TUser>
        : AliceResponseBase<AliceGalleryResponseModel, TSession, TUser>
    {
        public AliceGalleryResponse(AliceRequestBase request, string text)
            : this(request, text, text, null)
        {
        }

        public AliceGalleryResponse(AliceRequestBase request, string text, string tts)
            : this(request, text, tts, null)
        {
        }

        public AliceGalleryResponse(AliceRequestBase request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }


        public AliceGalleryResponse(AliceRequestBase request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request, text, tts, buttons)
        {
        }
    }
}
