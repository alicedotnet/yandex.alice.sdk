using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Models;
using Yandex.Alice.Sdk.Resources;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Models;

namespace Yandex.Alice.Sdk.Tests.Models
{
    public class AliceRequestTests : BaseTests
    {
        public AliceRequestTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void Deserialization_Generic_Ok()
        {
            string requestJson = File.ReadAllText(TestsConstants.Assets.AliceRequestFilePath);
            var aliceRequest = JsonSerializer.Deserialize<AliceRequest<TestIntents, object, object>>(requestJson);
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
            foreach (AliceEntityModel entity in aliceRequest.Request.Nlu.Entities)
            {
                Assert.NotNull(entity.Tokens);
                Assert.NotEqual(AliceEntityType.Unknown, entity.Type);
            }
            Assert.NotNull(aliceRequest.Request.Nlu.Intents);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots);

            Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot.Tokens);
            Assert.Equal(AliceEntityType.STRING, aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot.Type);
            Assert.True(aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot is AliceEntityStringModel);
            Assert.NotNull((aliceRequest.Request.Nlu.Intents.Main.Slots.WhatSlot as AliceEntityStringModel).Value);
            
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot.Tokens);
            Assert.Equal(AliceEntityType.STRING, aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot.Type);
            Assert.True(aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot is AliceEntityStringModel);
            Assert.NotNull((aliceRequest.Request.Nlu.Intents.Main.Slots.WhereSlot as AliceEntityStringModel).Value);

            Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot);
            Assert.NotNull(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot.Tokens);
            Assert.Equal(AliceEntityType.STRING, aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot.Type);
            Assert.True(aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot is AliceEntityStringModel);
            Assert.NotNull((aliceRequest.Request.Nlu.Intents.MainSecondary.Slots.WhoSlot as AliceEntityStringModel).Value);

            WritePrettyJson(aliceRequest);
        }

        [Fact]
        public void Deserialization_Ok()
        {
            string requestJson = File.ReadAllText(TestsConstants.Assets.AliceRequestFilePath);
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
            foreach (AliceEntityModel entity in aliceRequest.Request.Nlu.Entities)
            {
                Assert.NotNull(entity.Tokens);
                Assert.NotEqual(AliceEntityType.Unknown, entity.Type);
            }
            Assert.NotNull(aliceRequest.Request.Nlu.Intents);
            WritePrettyJson(aliceRequest);
        }

        [Fact]
        public void UnknownRequestType_Error()
        {
            const string unknownTypeValue = "iamunknown";
            string json = $"{{\"request\": {{ \"type\": \"{unknownTypeValue}\" }}}}";
            var exception = Assert.Throws<Exception>(() => JsonSerializer.Deserialize<AliceRequest>(json));
            string message = string.Format(CultureInfo.CurrentCulture, Yandex_Alice_Sdk_Resources.Error_Unknown_Request_Type, unknownTypeValue);
            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void NumberInPayload_CastToInt_Success()
        {
            int expectedPayload = 1;
            string json = "{\"request\": { \"payload\":" + expectedPayload + "}}";
            var request = JsonSerializer.Deserialize<AliceRequest>(json);
            Assert.NotNull(request);
            int actualPayload = request.Request.GetPayload<int>();
            Assert.Equal(expectedPayload, actualPayload);
        }
    }
}
