namespace Yandex.Alice.Sdk.Demo.IntegrationTests.Controllers;

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;
using Yandex.Alice.Sdk.Demo.Services.Interfaces;

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

    [Fact]
    public async Task TestImageUpload()
    {
        var json = await File.ReadAllTextAsync(TestsConstants.AliceRequestResourcesFilePath);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("alice", content).ConfigureAwait(false);
        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Assert.True(response.StatusCode == HttpStatusCode.OK, responseContent);
        Assert.Contains(@"Изображение загружено", responseContent);

        _testOutputHelper.WriteLine(responseContent);

        await _cleanService.CleanResourcesAsync().ConfigureAwait(false);
    }

    [Theory]
    [InlineData(TestsConstants.AliceRequestFilePath)]
    [InlineData(TestsConstants.AliceRequestInvalidIntentFilePath)]
    [InlineData(TestsConstants.AliceRequestPingFilePath)]
    public async Task TestAlice(string filePath)
    {
        var json = await File.ReadAllTextAsync(filePath);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("alice", content).ConfigureAwait(false);
        var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Assert.True(response.StatusCode == HttpStatusCode.OK, responseContent);

        _testOutputHelper.WriteLine(responseContent);
    }
}