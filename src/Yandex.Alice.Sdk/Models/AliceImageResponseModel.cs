namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceImageResponseModel : AliceResponseModel
    {
        [JsonPropertyName("card")]
        public AliceImageCardModel Card { get; set; }
    }
}
