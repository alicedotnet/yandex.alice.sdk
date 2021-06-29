namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class DialogsImageInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("origUrl")]
        public Uri OriginalUrl { get; set; }

        [JsonPropertyName("size")]
        public int? Size { get; set; }

        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(DialogsDateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
