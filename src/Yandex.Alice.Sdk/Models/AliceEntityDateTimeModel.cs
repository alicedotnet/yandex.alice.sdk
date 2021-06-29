namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;

    public class AliceEntityDateTimeModel : AliceEntityModel
    {
        [JsonPropertyName("value")]
        public AliceEntityDateTimeValueModel Value { get; set; }
    }

    public class AliceEntityDateTimeValueModel
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }

        [JsonPropertyName("day_is_relative")]
        public bool DayIsRelative { get; set; }
    }
}
