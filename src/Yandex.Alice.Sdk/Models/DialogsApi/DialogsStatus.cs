namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public class DialogsStatus
    {
        [JsonPropertyName("images")]
        public DialogsDataUsageModel Images { get; set; }

        [JsonPropertyName("sounds")]
        public DialogsDataUsageModel Sounds { get; set; }
    }
}
