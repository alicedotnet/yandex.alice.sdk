namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

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
