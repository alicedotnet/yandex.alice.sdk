using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsResponseContent
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("payload")]
        public DialogsResponsePayload Payload { get; set; }
    }

    public class DialogsResponsePayload
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
