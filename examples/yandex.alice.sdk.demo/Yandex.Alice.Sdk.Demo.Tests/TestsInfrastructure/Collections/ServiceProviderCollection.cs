using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Fixtures;

namespace Yandex.Alice.Sdk.Demo.Tests.TestsInfrastructure.Collections
{
    [CollectionDefinition(TestsConstants.ServiceProviderCollection)]
    public class ServiceProviderCollection 
        : ICollectionFixture<ServiceProviderFixture>
    {
    }
}
