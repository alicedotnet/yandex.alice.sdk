namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsDataUsageModel
    {
        [JsonPropertyName("quota")]
        public DialogsQuotaModel Quota { get; set; }
    }
}
