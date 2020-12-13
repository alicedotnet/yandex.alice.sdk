using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;

namespace Yandex.Alice.Sdk.Demo.IntegrationTests.Controllers
{
    [Collection(TestsConstants.TestServerCollectionName)]
    public class AliceControllerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;
        private readonly ICleanService _cleanService;

        public AliceControllerTests(ITestOutputHelper testOutputHelper, TestServerFixture testServerFixture)
        {
            _testOutputHelper = testOutputHelper;
            _client = testServerFixture.DemoClient;
            _cleanService = testServerFixture.Services.GetRequiredService<ICleanService>();
        }

        [Theory]
        [InlineData(TestsConstants.AliceRequestResourcesFilePath, true)]
        public async Task TestAlice(string filePath, bool cleanResources)
        {
            string json = File.ReadAllText(filePath);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("alice", content).ConfigureAwait(false);
            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.True(HttpStatusCode.OK == response.StatusCode, responseContent);

            _testOutputHelper.WriteLine(responseContent);

            if (cleanResources)
            {
                await _cleanService.CleanResourcesAsync().ConfigureAwait(false);
            }
        }
    }
}
