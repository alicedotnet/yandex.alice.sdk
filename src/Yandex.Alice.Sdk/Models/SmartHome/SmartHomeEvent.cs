namespace Yandex.Alice.Sdk.Models.SmartHome
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmartHomeEvent
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public SmartHomeEvent(string value)
        {
            Value = value;
        }
    }
}
