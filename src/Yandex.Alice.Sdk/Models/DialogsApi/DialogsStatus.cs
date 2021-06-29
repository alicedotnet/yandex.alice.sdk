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

    public class DialogsDataUsageModel
    {
        [JsonPropertyName("quota")]
        public DialogsQuotaModel Quota { get; set; }
    }

    public class DialogsQuotaModel
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("used")]
        public int Used { get; set; }
    }
}
