namespace Yandex.Alice.Sdk.Models.IoTApi
{
    using System.Text.Json.Serialization;

    public class IoTResponseBase
    {
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
