using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsImageUploadRequest
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        public DialogsImageUploadRequest(Uri url)
        {
            Url = url;
        }
    }
}
