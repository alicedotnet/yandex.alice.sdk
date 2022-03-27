namespace Yandex.Alice.Sdk.Tests.Models;

using System.Globalization;
using System.IO;
using System.Text.Json;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Exceptions;
using Yandex.Alice.Sdk.Models;
using Yandex.Alice.Sdk.Resources;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

public class AliceRequestTests : BaseTests
{
    public AliceRequestTests(ITestOutputHelper testOutputHelper)
        : base(testOutputHelper)
    {
    }

    [Fact]
    public void Deserialization_Generic_Ok()
    {
        var requestJson = File.ReadAllText(TestsConstants.Assets.AliceRequestFilePath);
        var aliceRequest = JsonSerializer.Deserialize<AliceRequest<TestIntents, object, object>>(requestJson);
        Assert.NotNull(aliceRequest);
        Assert.NotNull(aliceRequest.Meta);
        Assert.NotNull(aliceRequest.Meta.Interfaces);
        Assert.NotNull(aliceRequest.Meta.Interfaces.GeolocationSharing);
        Assert.NotNull(aliceRequest.State);
        Assert.NotNull(aliceRequest.State.Session);
        Assert.NotNull(aliceRequest.State.User);
        Assert.NotNull(aliceRequest.Session);
        Assert.True(aliceRequest.Session.MessageId > 0);
        Assert.NotEmpty(aliceRequest.Session.SessionId);
        Assert.NotEmpty(aliceRequest.Session.SkillId);
        Assert.NotEmpty(aliceRequest.Session.UserId);
        Assert.NotNull(aliceRequest.Session.User);
        Assert.NotEmpty(aliceRequest.Session.User.UserId);
        Assert.NotEmpty(aliceRequest.Session.User.AccessToken);
        Assert.NotNull(aliceRequest.Session.Application);
        Assert.NotEmpty(aliceRequest.Session.Application.ApplicationId);
        Assert.NotNull(aliceRequest.Session.Location);
        Assert.True(aliceRequest.Session.Location.Lat > 0);
        Assert.True(aliceRequest.Session.Location.Lon > 0);
        Assert.True(aliceRequest.Session.Location.Accuracy > 0);
        Assert.True(aliceRequest.Session.New);
        Assert.NotNull(aliceRequest.Request);
        Assert.NotNull(aliceRequest.Request.Nlu);
        Assert.NotNull(aliceRequest.Request.Nlu.Tokens);
        Assert.NotEmpty(aliceRequest.Request.Nlu.Tokens);
        Assert.NotNull(aliceRequest.Request.Nlu.Entities);
        Assert.NotEmpty(aliceRequest.Request.Nlu.Entities);
        foreach (var entity in aliceRequest.Request.Nlu.Entities)
        {
            Assert.NotNull(entity.Tokens);
            Assert.NotEqual(AliceEntityType.Unknown, entity.Type);
        }

        Assert.NotNull(aliceRequest.Request.Nlu.Intents);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots);

        Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot.Tokens);
        Assert.Equal(AliceEntityType.String, aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot.Type);
        Assert.True(aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot is AliceEntityStringModel);
        Assert.NotNull((aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot as AliceEntityStringModel).Value);

        Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot.Tokens);
        Assert.Equal(AliceEntityType.String, aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot.Type);
        Assert.True(aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot is AliceEntityStringModel);
        Assert.NotNull((aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot as AliceEntityStringModel).Value);

        Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot);
        Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot.Tokens);
        Assert.Equal(AliceEntityType.String, aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot.Type);
        Assert.True(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot is AliceEntityStringModel);
        Assert.NotNull((aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot as AliceEntityStringModel).Value);

        WritePrettyJson(aliceRequest);
    }

    [Fact]
    public void Deserialization_Ok()
    {
        var requestJson = File.ReadAllText(TestsConstants.Assets.AliceRequestFilePath);
        var aliceRequest = JsonSerializer.Deserialize<AliceRequest>(requestJson);
        Assert.NotNull(aliceRequest);
        Assert.NotNull(aliceRequest.State);
        Assert.NotNull(aliceRequest.State.Session);
        Assert.NotNull(aliceRequest.State.User);
        Assert.NotNull(aliceRequest.Session);
        Assert.True(aliceRequest.Session.MessageId > 0);
        Assert.NotEmpty(aliceRequest.Session.SessionId);
        Assert.NotEmpty(aliceRequest.Session.SkillId);
        Assert.NotEmpty(aliceRequest.Session.UserId);
        Assert.NotNull(aliceRequest.Session.User);
        Assert.NotEmpty(aliceRequest.Session.User.UserId);
        Assert.NotEmpty(aliceRequest.Session.User.AccessToken);
        Assert.NotNull(aliceRequest.Session.Application);
        Assert.NotEmpty(aliceRequest.Session.Application.ApplicationId);
        Assert.True(aliceRequest.Session.New);
        Assert.NotNull(aliceRequest.Request);
        Assert.NotNull(aliceRequest.Request.Nlu);
        Assert.NotNull(aliceRequest.Request.Nlu.Tokens);
        Assert.NotEmpty(aliceRequest.Request.Nlu.Tokens);
        Assert.NotNull(aliceRequest.Request.Nlu.Entities);
        Assert.NotEmpty(aliceRequest.Request.Nlu.Entities);
        foreach (var entity in aliceRequest.Request.Nlu.Entities)
        {
            Assert.NotNull(entity.Tokens);
            Assert.NotEqual(AliceEntityType.Unknown, entity.Type);
        }

        Assert.NotNull(aliceRequest.Request.Nlu.Intents);
        WritePrettyJson(aliceRequest);
    }

    [Fact]
    public void Deserialization_PurchaseConfirmation_Ok()
    {
        // arrange
        var requestJson = File.ReadAllText(TestsConstants.Assets.AliceRequestPurchaseConfirmationFilePath);

        // act
        var aliceRequest = JsonSerializer.Deserialize<AliceRequest>(requestJson);

        // assert
        aliceRequest.Should().NotBeNull();
        aliceRequest.Request.Should().NotBeNull();
        aliceRequest.Request.Type.Should().Be(AliceRequestType.PurchaseConfirmation);
        aliceRequest.Request.PurchaseRequestId.Should().NotBeNullOrEmpty()
            .And.Be("d432de19be8347d09f656d9fe966e2f9");
        aliceRequest.Request.PurchaseToken.Should().NotBeNullOrEmpty()
            .And.Be("token_value");
        aliceRequest.Request.OrderId.Should().NotBeNullOrEmpty()
            .And.Be("eeb59d64-9e6a-11ea-bb37-0242ac130002");
        aliceRequest.Request.PurchaseTimestamp.Should().Be(1590399311);

        aliceRequest.Request.PurchasePayload.Should().NotBeNull();
        aliceRequest.Request.GetPurchasePayload<int>().Should().Be(123);

        aliceRequest.Request.SignedData.Should().NotBeNullOrEmpty()
            .And.Be("purchase_request_id=d432de19be8347d09f656d9fe966e2f9&purchase_token=token_value&order_id=eeb59d64-9e6a-11ea-bb37-0242ac130002&...");
        aliceRequest.Request.Signature.Should().NotBeNullOrEmpty()
            .And.Be(@"Pi6JNCFeeleRa...");
        WritePrettyJson(aliceRequest);
    }

    [Fact]
    public void UnknownRequestType_Error()
    {
        const string unknownTypeValue = "unknown";
        const string json = $"{{\"request\": {{ \"type\": \"{unknownTypeValue}\" }}}}";
        var exception = Assert.Throws<UnknownRequestTypeException>(() => JsonSerializer.Deserialize<AliceRequest>(json));
        var message = string.Format(CultureInfo.CurrentCulture, AliceResources.Error_Unknown_Request_Type, unknownTypeValue);
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void NumberInPayload_CastToInt_Success()
    {
        const int expectedPayload = 1;
        var json = "{\"request\": { \"payload\":" + expectedPayload + "}}";
        var request = JsonSerializer.Deserialize<AliceRequest>(json);
        Assert.NotNull(request);
        var actualPayload = request.Request.GetPayload<int>();
        Assert.Equal(expectedPayload, actualPayload);
    }
}