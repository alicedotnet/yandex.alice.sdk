namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System;
    using System.Text.Json.Serialization;
    using Yandex.Alice.Sdk.Converters;

    public class DialogsSoundInfo
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("skillId")]
        public Guid SkillId { get; set; }

        [JsonPropertyName("size")]
        public int? Size { get; set; }

        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }

        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(DialogsDateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("isProcessed")]
        public bool IsProcessed { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }
}
