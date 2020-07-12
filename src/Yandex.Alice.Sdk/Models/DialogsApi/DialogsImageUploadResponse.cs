using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsImageUploadResponse
    {
        [JsonPropertyName("image")]
        public DialogsImageInfo Image { get; set; }
    }
}
