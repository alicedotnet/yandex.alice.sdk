namespace Yandex.Alice.Sdk.Demo.IntegrationTests.Services
{
    using System.Threading.Tasks;
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
            await _cleanService.CleanResourcesAsync().ConfigureAwait(false);
        }
    }
}
