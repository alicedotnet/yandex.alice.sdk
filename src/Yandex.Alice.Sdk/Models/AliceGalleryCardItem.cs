namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

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
