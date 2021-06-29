using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Fixtures;

namespace Yandex.Alice.Sdk.Demo.IntegrationTests.TestsInfrastructure.Collections
{
    [CollectionDefinition(TestsConstants.TestServerCollectionName)]
    public class TestServerCollection : ICollectionFixture<TestServerFixture>
    {
    }
}
