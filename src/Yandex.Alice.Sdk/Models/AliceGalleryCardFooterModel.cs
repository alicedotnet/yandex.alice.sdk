using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryCardFooterModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("button")]
        public AliceImageCardButtonModel Button { get; set; }

        public AliceGalleryCardFooterModel()
        {

        }

        public AliceGalleryCardFooterModel(string text , AliceImageCardButtonModel button)
        {
            Text = text;
            Button = button;
        }
    }
}
