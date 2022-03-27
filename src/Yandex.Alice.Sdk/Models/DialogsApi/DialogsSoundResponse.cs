namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsSoundResponse
    {
        [JsonPropertyName("sound")]
        public DialogsSoundInfo Sound { get; set; }
    }
}
