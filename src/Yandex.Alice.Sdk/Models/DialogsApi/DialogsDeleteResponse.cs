namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class DialogsDeleteResponse
    {
        [JsonPropertyName("result")]
        [JsonConverter(typeof(DialogsResultTypeConverter))]
        public DialogsResultType Result { get; set; }
    }
}
