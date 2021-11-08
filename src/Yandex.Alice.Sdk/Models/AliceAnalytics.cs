namespace Yandex.Alice.Sdk.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AliceAnalytics
    {
        [JsonPropertyName("events")]
        public List<AliceAnalyticsEvent> Events { get; set; }
    }
}
