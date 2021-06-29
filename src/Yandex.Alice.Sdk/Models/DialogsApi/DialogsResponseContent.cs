namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public class DialogsResponseContent
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("payload")]
        public DialogsResponsePayload Payload { get; set; }
    }

    public class DialogsResponsePayload
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
