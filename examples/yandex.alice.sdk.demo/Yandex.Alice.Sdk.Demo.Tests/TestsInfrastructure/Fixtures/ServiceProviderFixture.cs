using System;
using System.Collections.Generic;
using System.Text;

namespace Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures
{
    public class ServiceProviderFixture
    {
        public IServiceProvider Services { get; }

        public ServiceProviderFixture()
        {
            var host = HostBuilderConfiguration.CreateHostBuilder()
                .Build();
            Services = host.Services;
        }
    }
}
