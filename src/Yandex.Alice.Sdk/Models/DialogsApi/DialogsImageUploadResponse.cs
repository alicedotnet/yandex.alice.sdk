namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsImageUploadResponse
    {
        [JsonPropertyName("image")]
        public DialogsImageInfo Image { get; set; }
    }
}
