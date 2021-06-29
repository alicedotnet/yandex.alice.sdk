namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceEntityGeoModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public AliceEntityGeoValueModel Value { get; set; }
    }

    public class AliceEntityGeoValueModel
    {
        [JsonPropertyName("house_number")]
        public string HouseNumber { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }
    }
}
