using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsWebUploadRequest
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        public DialogsWebUploadRequest(Uri url)
        {
            Url = url;
        }
    }
}
