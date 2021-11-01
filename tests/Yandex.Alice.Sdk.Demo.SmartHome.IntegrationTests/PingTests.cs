namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class PingTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PingTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Ping()
        {
            // arrange
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Head,
                RequestUri = new Uri("v1.0", UriKind.Relative),
            };

            // act
            var response = await _client.SendAsync(request);

            // assert
            string content = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK, content);
        }
    }
}
