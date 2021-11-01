namespace Yandex.Alice.Sdk.Demo.IntegrationTests.Services
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;
    using Yandex.Alice.Sdk.Demo.Services.Interfaces;

    [Collection(TestsConstants.TestServerCollectionName)]
    public class CleanServiceTests
    {
        private readonly ICleanService _cleanService;

        public CleanServiceTests(TestServerFixture serviceProviderFixture)
        {
            _cleanService = serviceProviderFixture.Services.GetRequiredService<ICleanService>();
        }

        [Fact]
        public async Task CleanResources()
        {
            // arrange
            // act
            Func<Task> act = async () => await _cleanService.CleanResourcesAsync().ConfigureAwait(false);

            // assert
            await act.Should().NotThrowAsync();
        }
    }
}
