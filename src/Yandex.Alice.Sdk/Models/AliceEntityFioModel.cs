namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceEntityFioModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public AliceEntityFioValueModel Value { get; set; }
    }

    public class AliceEntityFioValueModel
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
