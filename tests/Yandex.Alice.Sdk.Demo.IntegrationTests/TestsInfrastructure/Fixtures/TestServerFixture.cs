namespace Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;

using System;
using System.Net.Http;
using JetBrains.Annotations;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

[UsedImplicitly]
public class TestServerFixture
{
    public HttpClient DemoClient { get; }

    public IServiceProvider Services { get; }

    public TestServerFixture()
    {
        var hostBuilder = CreateHostBuilder()
            .ConfigureWebHost(webHost => webHost.UseTestServer());
        var host = hostBuilder.Start();
        Services = host.Services;
        DemoClient = host.GetTestClient();
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Program.CreateHostBuilder(Array.Empty<string>())
            .ConfigureAppConfiguration(c => c
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<TestServerFixture>(true)
                .AddEnvironmentVariables());
    }
}