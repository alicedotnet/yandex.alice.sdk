namespace Yandex.Alice.Sdk.Demo.Models.Session;

using System.Text.Json.Serialization;

public class CustomSessionState
{
    [JsonPropertyName("mode")]
    public ModeType Mode { get; }

    public CustomSessionState(ModeType mode = ModeType.Undefined)
    {
        Mode = mode;
    }
}