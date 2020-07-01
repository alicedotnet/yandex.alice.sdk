using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Models;

namespace Yandex.Alice.Sdk.Demo.Tests.Controllers
{
    public class AliceControllerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AliceControllerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task TestAlice()
        {
            var hostBuilder = Program.CreateHostBuilder(Array.Empty<string>())
                .ConfigureWebHost(webhost => webhost.UseTestServer());
            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();

            string json = File.ReadAllText(TestsConstants.AliceRequestFilePath);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("alice", content).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            _testOutputHelper.WriteLine(responseContent);
        }
    }
}
