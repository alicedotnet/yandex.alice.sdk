namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public class DialogsResponsePayload
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
