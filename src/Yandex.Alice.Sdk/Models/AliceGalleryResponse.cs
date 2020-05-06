using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryResponse : AliceResponseBase<AliceGalleryResponseModel>
    {
        public AliceGalleryResponse()
        {

        }

        public AliceGalleryResponse(AliceRequest request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Version = request.Version;
            Response = new AliceGalleryResponseModel()
            {
                Text = text,
                Tts = tts,
                Card = new AliceGalleryCardModel()
                {
                    Type = AliceCardType.ItemsList,
                },
                Buttons = buttons
            };
        }
    }
}
