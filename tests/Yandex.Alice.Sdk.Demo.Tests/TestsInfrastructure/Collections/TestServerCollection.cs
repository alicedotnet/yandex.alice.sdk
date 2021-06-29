namespace Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Collections
{
    using Xunit;
    using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures;

    [CollectionDefinition(TestsConstants.TestServerCollectionName)]
    public class TestServerCollection : ICollectionFixture<TestServerFixture>
    {
    }
}
