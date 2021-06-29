namespace Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Moq;
    using Yandex.Alice.Sdk.Demo.Workers;
    using Yandex.Alice.Sdk.Services;

    public class TestServerFixture
    {
        public HttpClient DemoClient { get; }

        public IServiceProvider Services { get; }

        public TestServerFixture()
        {
            var hostBuilder = Program.CreateHostBuilder(Array.Empty<string>())
                .ConfigureServices(serviceCollection =>
                {
                    var workerDescriptor = serviceCollection
                        .FirstOrDefault(x => x.ImplementationType == typeof(CleanResourcesWorker));
                    serviceCollection.Remove(workerDescriptor);

                    var dialogsServiceDescriptor = serviceCollection
                        .FirstOrDefault(x => x.ImplementationType == typeof(DialogsApiService));
                    serviceCollection.Remove(dialogsServiceDescriptor);
                    var dialogsServiceMock = new Mock<IDialogsApiService>();
                    serviceCollection.AddSingleton(dialogsServiceMock.Object);
                })
                .ConfigureWebHost(webhost => webhost.UseTestServer());
            var host = hostBuilder.Start();
            Services = host.Services;
            DemoClient = host.GetTestClient();
        }
    }
}
