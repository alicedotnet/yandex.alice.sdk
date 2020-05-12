using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryResponse : AliceResponseBase<AliceGalleryResponseModel>
    {
        public AliceGalleryResponse(AliceRequest request, string text)
            : this(request, text, text, null)
        {
        }

        public AliceGalleryResponse(AliceRequest request, string text, string tts)
            : this(request, text, tts, null)
        {
        }

        public AliceGalleryResponse(AliceRequest request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }


        public AliceGalleryResponse(AliceRequest request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request, text, tts, buttons)
        {
        }
    }
}
