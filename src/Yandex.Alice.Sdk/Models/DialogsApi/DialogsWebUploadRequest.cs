namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
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
