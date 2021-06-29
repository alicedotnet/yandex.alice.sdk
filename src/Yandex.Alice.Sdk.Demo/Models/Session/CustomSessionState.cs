namespace Yandex.Alice.Sdk.Demo.Models.Session
{
    using System.Text.Json.Serialization;

    public class CustomSessionState
    {
        [JsonPropertyName("mode")]
        public ModeType Mode { get; set; }

        public CustomSessionState(ModeType mode)
        {
            Mode = mode;
        }

        public CustomSessionState()
        {
        }
    }
}
