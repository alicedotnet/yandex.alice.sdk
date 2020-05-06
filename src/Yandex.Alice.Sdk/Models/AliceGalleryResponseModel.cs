using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryResponseModel : AliceResponseModel
    {
        [JsonPropertyName("card")]
        public AliceGalleryCardModel Card { get; set; }
    }
}
