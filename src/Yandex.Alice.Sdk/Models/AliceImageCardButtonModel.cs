namespace Yandex.Alice.Sdk.Models
{
    using System;
    using System.Text.Json.Serialization;

    public class AliceImageCardButtonModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }
    }
}
