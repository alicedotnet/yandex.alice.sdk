namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System;
    using System.Text.Json.Serialization;

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
