using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures
{
    static class HostBuilderConfiguration
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Program.CreateHostBuilder(Array.Empty<string>())
                .ConfigureAppConfiguration(c => c.AddUserSecrets<TestServerFixture>());
        }
    }
}
