namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceSessionApplicationModel
    {
        [JsonPropertyName("application_id")]
        public string ApplicationId { get; set; }
    }
}
