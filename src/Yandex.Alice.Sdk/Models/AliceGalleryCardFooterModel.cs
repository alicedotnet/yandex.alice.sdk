namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceGalleryCardFooterModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("button")]
        public AliceImageCardButtonModel Button { get; set; }

        public AliceGalleryCardFooterModel()
        {
        }

        public AliceGalleryCardFooterModel(string text)
            : this(text, null)
        {
        }

        public AliceGalleryCardFooterModel(string text, AliceImageCardButtonModel button)
        {
            Text = text;
            Button = button;
        }
    }
}
