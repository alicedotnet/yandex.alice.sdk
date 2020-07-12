using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Yandex.Alice.Sdk.Converters;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsImageInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("origUrl")]
        public Uri OriginalUrl { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(DialogsDateConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
