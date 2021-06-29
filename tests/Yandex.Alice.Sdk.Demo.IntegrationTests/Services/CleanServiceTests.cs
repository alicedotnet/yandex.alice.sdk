using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;

namespace Yandex.Alice.Sdk.Demo.IntegrationTests.Services
{
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
