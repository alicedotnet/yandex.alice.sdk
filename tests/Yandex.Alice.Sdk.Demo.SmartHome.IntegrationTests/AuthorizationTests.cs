namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FluentAssertions;
    using IdentityServer4;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure;

    public class AuthorizationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AuthorizationTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetToken()
        {
            // arrange
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "scope", IdentityServerConstants.LocalApi.ScopeName },
                { "client_id", "oauthClient" },
                { "client_secret", "SuperSecretPassword" },
            };
            var payload = new FormUrlEncodedContent(parameters);

            // act
            var response = await _client.PostAsync("/connect/token", payload);

            // assert
            string content = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK, content);

            var token = JsonSerializer.Deserialize<TestToken>(content);
            token.Should().NotBeNull();
            token.AccessToken.Should().NotBeNullOrEmpty();
        }
    }
}
