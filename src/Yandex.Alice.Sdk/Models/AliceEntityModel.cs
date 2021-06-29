namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class AliceEntityModel
    {
        [JsonPropertyName("tokens")]
        public AliceTokensModel Tokens { get; set; }

        [JsonPropertyName(AliceConstants.AliceEntityModelFields.Type)]
        [JsonConverter(typeof(AliceEntityTypeConverter))]
        public AliceEntityType Type { get; set; }
    }
}
