namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;

    public class AuthorizationTests : IClassFixture<SmartHomeFixture>
    {
        private readonly SmartHomeFixture _smartHomeFixture;

        public AuthorizationTests(SmartHomeFixture smartHomeFixture)
        {
            _smartHomeFixture = smartHomeFixture;
        }

        [Fact]
        public void GetToken()
        {
            // arrange
            // act
            // assert
            _smartHomeFixture.Token.Should().NotBeNull();
            _smartHomeFixture.Token.AccessToken.Should().NotBeNullOrEmpty();
            _smartHomeFixture.Token.RefreshToken.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task RefreshToken()
        {
            // arrange
            var refreshToken = _smartHomeFixture.Token.RefreshToken;
            var refreshTokenParameters = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken },
                { "client_id", "alice" },
            };
            var payload = new FormUrlEncodedContent(refreshTokenParameters);

            // act
            var response = await _smartHomeFixture.Client.PostAsync("/connect/token", payload);

            // assert
            string content = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK, content);
            content.Should().NotContain("error");

            var token = JsonSerializer.Deserialize<TestToken>(content);
            token.Should().NotBeNull();
            token.AccessToken.Should().NotBeNullOrEmpty();
            token.RefreshToken.Should().NotBeNullOrEmpty();
        }
    }
}
