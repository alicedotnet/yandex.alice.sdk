namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public abstract class DialogsCallbackRequest<TPayload>
    {
        [JsonPropertyName("ts")]
        public double Timestamp { get; set; }

        [JsonPropertyName("payload")]
        public TPayload Payload { get; set; }
    }
}
