using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Fixtures;

namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Collection
{
    [CollectionDefinition(TestsConstants.DialogsApiCollectionName)]
    public class DialogsApiCollection : ICollectionFixture<DialogsApiFixture>
    {
    }
}
