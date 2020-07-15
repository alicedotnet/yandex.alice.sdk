using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;
using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Yandex.Alice.Sdk.Demo.Tests.Services
{
    [Collection(TestsConstants.ServiceProviderCollection)]
    public class CleanServiceTests
    {
        private readonly ICleanService _cleanService;

        public CleanServiceTests(ServiceProviderFixture serviceProviderFixture)
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
