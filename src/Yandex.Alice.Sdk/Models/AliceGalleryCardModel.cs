using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryCardModel
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(AliceCardTypeConverter))]
        public AliceCardType Type { get; set; }
        [JsonPropertyName("header")]
        public AliceGalleryCardHeaderModel Header { get; set; }
        [JsonPropertyName("items")]
        public List<AliceGalleryCardItem> Items { get; set; }
        [JsonPropertyName("footer")]
        public AliceGalleryCardFooterModel Footer { get; set; }
    }
}
