namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public class DialogsSoundResponse
    {
        [JsonPropertyName("sound")]
        public DialogsSoundInfo Sound { get; set; }
    }
}
