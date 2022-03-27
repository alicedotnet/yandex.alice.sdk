namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsCallbackDiscoveryPayload
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
