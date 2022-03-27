namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Yandex.Alice.Sdk.Converters;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class DialogsDeleteResponse
    {
        [JsonPropertyName("result")]
        [JsonConverter(typeof(DialogsResultTypeConverter))]
        public DialogsResultType Result { get; set; }
    }
}
