namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Yandex.Alice.Sdk.Models;

[UsedImplicitly]
public class TestIntents
{
    public TestIntents(AliceIntentModel<MainIntentSlots> main, AliceIntentModel<MainSecondaryIntentSlots> mainSecondary)
    {
        Main = main;
        MainSecondary = mainSecondary;
    }

    [JsonPropertyName("main")]
    public AliceIntentModel<MainIntentSlots> Main { get; }

    [JsonPropertyName("main_secondary")]
    public AliceIntentModel<MainSecondaryIntentSlots> MainSecondary { get; }
}