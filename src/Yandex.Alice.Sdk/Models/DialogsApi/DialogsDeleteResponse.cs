using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsDeleteResponse
    {
        [JsonPropertyName("result")]
        [JsonConverter(typeof(DialogsResultTypeConverter))]
        public DialogsResultType Result { get; set; }
    }
}
