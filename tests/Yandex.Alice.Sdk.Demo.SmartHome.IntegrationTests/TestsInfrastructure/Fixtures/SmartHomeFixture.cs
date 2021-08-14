namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using IdentityServer4;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class SmartHomeFixture : IAsyncLifetime
    {
        public HttpClient Client { get; }

        public string Token { get; private set; }

        public SmartHomeFixture()
        {
            var factory = new WebApplicationFactory<Startup>();
            Client = factory.CreateClient();
        }

        public async Task InitializeAsync()
        {
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "scope", IdentityServerConstants.LocalApi.ScopeName },
                { "client_id", "oauthClient" },
                { "client_secret", "SuperSecretPassword" },
            };
            var payload = new FormUrlEncodedContent(parameters);

            var response = await Client.PostAsync("/connect/token", payload);

            string content = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<TestToken>(content);
            Token = token.AccessToken;
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}
