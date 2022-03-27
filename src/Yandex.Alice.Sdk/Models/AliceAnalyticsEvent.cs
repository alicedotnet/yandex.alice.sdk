namespace Yandex.Alice.Sdk.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AliceAnalyticsEvent
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public object Value { get; set; }

        public AliceAnalyticsEvent()
        {
        }

        public AliceAnalyticsEvent(string name, object value = null)
        {
            Name = name;
            Value = value;
        }
    }
}
