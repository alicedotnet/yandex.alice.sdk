using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceResponse : AliceResponseBase<AliceResponseModel>
    {       
        public AliceResponse()
        {

        }

        public AliceResponse(AliceRequest request, string text, List<AliceButtonModel> buttons)
            : this(request, text, text, buttons)
        {
        }

        public AliceResponse(AliceRequest request, string text, string tts, List<AliceButtonModel> buttons)
            : base(request)
        {
            Response = new AliceResponseModel()
            {
                Text = text,
                Tts = tts,
                Buttons = buttons
            };
        }
    }
}
