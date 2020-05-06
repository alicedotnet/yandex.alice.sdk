using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryCardHeaderModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        public AliceGalleryCardHeaderModel()
        {

        }

        public AliceGalleryCardHeaderModel(string text)
        {
            Text = text;
        }
    }
}
