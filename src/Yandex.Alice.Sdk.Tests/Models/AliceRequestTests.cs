using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Models;
using Yandex.Alice.Sdk.Resources;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure;

namespace Yandex.Alice.Sdk.Tests.Models
{
    public class AliceRequestTests : BaseTests
    {
        public AliceRequestTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
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
    }
}
