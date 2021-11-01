namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;
    using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;
    using Yandex.Alice.Sdk.Models.SmartHome;

    public class UnlinkControllerTests : BaseAuthorizedControllerTests
    {
        public UnlinkControllerTests(SmartHomeFixture smartHomeFixture)
            : base(smartHomeFixture)
        {
        }

        [Fact]
        public async Task Unlink()
        {
            // arrange
            var payload = new StringContent(string.Empty);
            var requestId = Guid.NewGuid().ToString();
            Client.DefaultRequestHeaders.Add("X-Request-Id", requestId);

            // act
            var response = await Client.PostAsync("v1.0/user/unlink", payload);

            // assert
            var content = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK, content);
            var unlinkResponse = JsonSerializer.Deserialize<SmartHomeResponseAccountUnlink>(content);
            unlinkResponse.Should().NotBeNull();
            unlinkResponse.RequestId.Should().NotBeNullOrEmpty()
                .And.Be(requestId);
        }
    }
}
