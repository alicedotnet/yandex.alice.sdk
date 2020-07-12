using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsStatusModel
    {
        [JsonPropertyName("images")]
        public DialogsDataUsageModel Images {get;set;}

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
