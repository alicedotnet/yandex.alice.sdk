namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public class DialogsDataUsageModel
    {
        [JsonPropertyName("quota")]
        public DialogsQuotaModel Quota { get; set; }
    }
}
