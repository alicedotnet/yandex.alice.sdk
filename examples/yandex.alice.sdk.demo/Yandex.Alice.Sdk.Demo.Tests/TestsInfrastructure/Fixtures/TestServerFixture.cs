using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures
{
    public class TestServerFixture
    {
        public HttpClient DemoClient { get; }
        public IServiceProvider Services { get; }

        public TestServerFixture()
        {
            var hostBuilder = HostBuilderConfiguration.CreateHostBuilder()
                .ConfigureWebHost(webhost => webhost.UseTestServer());
            var host = hostBuilder.Start();
            Services = host.Services;
            DemoClient = host.GetTestClient();
        }
    }
}
