namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsQuotaModel
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("used")]
        public int Used { get; set; }
    }
}
