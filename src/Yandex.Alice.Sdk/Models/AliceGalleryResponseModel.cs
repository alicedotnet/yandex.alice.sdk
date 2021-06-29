namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceGalleryResponseModel : AliceResponseModel
    {
        [JsonPropertyName("card")]
        public AliceGalleryCardModel Card { get; set; }
    }
}
