using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models
{
    public class AliceGalleryCardItem : AliceModel
    {
        [JsonPropertyName("image_id")]
        public string ImageId { get; set; }

        public const int MaxTitleLength = 128;
        private string _title;
        [JsonPropertyName("title")]
        public string Title 
        {
            get => _title;
            set
            {
                ValidateMaxLength(value, MaxTitleLength);
                _title = value;
            }
        }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("button")]
        public AliceImageCardButtonModel Button { get; set; }
    }
}
