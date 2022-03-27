namespace Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests;

using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;
using Yandex.Alice.Sdk.Demo.SmartHome.IntegrationTests.TestsInfrastructure.Fixtures;

public abstract class BaseAuthorizedControllerTests : IClassFixture<SmartHomeFixture>
{
    protected HttpClient Client { get; }

    protected BaseAuthorizedControllerTests(SmartHomeFixture smartHomeFixture)
    {
        Client = smartHomeFixture.Client;
        Client.DefaultRequestHeaders.Clear();
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", smartHomeFixture.Token.AccessToken);
    }
}