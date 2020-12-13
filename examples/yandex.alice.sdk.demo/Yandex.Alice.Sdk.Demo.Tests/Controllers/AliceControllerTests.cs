using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure;
using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures;

namespace Yandex.Alice.Sdk.Demo.Tests.Controllers
{
    [Collection(TestsConstants.TestServerCollectionName)]
    public class AliceControllerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;

        public AliceControllerTests(ITestOutputHelper testOutputHelper, TestServerFixture testServerFixture)
        {
            _testOutputHelper = testOutputHelper;
            _client = testServerFixture.DemoClient;
        }

        [Theory]
        [InlineData(TestsConstants.AliceRequestFilePath)]
        [InlineData(TestsConstants.AliceRequestInvalidIntentFilePath)]
        [InlineData(TestsConstants.AliceRequestPingFilePath)]
        public async Task TestAlice(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("alice", content).ConfigureAwait(false);
            string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.True(HttpStatusCode.OK == response.StatusCode, responseContent);

            _testOutputHelper.WriteLine(responseContent);
        }
    }
}
