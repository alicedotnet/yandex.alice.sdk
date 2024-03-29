﻿namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Yandex.Alice.Sdk.Converters;
using Yandex.Alice.Sdk.Models;

[UsedImplicitly]
public class MainIntentSlots
{
    public MainIntentSlots(AliceEntityStringModel whatSlot, AliceEntityModel whereSlot)
    {
        WhatSlot = whatSlot;
        WhereSlot = whereSlot;
    }

    [JsonPropertyName("what")]
    public AliceEntityStringModel WhatSlot { get; }

    [JsonPropertyName("where")]
    [JsonConverter(typeof(AliceEntityModelConverter))]
    public AliceEntityModel WhereSlot { get; }
}