namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;

    public class DialogsImageUploadResponse
    {
        [JsonPropertyName("image")]
        public DialogsImageInfo Image { get; set; }
    }
}
