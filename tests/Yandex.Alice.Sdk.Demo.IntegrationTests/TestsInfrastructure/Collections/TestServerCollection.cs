namespace Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Collections
{
    using Xunit;
    using Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;

    [CollectionDefinition(TestsConstants.TestServerCollectionName)]
    public class TestServerCollection : ICollectionFixture<TestServerFixture>
    {
    }
}
