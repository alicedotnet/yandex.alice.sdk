namespace Yandex.Alice.Sdk.Models
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceEntityDateTimeValueModel
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("year_is_relative")]
        public bool YearIsRelative { get; set; }

        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("month_is_relative")]
        public bool MonthIsRelative { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("day_is_relative")]
        public bool DayIsRelative { get; set; }

        [JsonPropertyName("hour")]
        public int Hour { get; set; }

        [JsonPropertyName("hour_is_relative")]
        public bool HourIsRelative { get; set; }

        [JsonPropertyName("minute")]
        public int Minute { get; set; }

        [JsonPropertyName("minute_is_relative")]
        public bool MinuteIsRelative { get; set; }
    }
}
