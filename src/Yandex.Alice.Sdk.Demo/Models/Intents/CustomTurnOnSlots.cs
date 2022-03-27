namespace Yandex.Alice.Sdk.Demo.Models.Intents;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Yandex.Alice.Sdk.Models;

[UsedImplicitly]
public class CustomTurnOnSlots
{
    public CustomTurnOnSlots(AliceEntityStringModel what, AliceEntityStringModel where)
    {
        What = what;
        Where = where;
    }

    [JsonPropertyName("what")]
    public AliceEntityStringModel What { get; }

    [JsonPropertyName("where")]
    public AliceEntityStringModel Where { get; }
}