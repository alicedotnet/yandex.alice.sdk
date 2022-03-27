namespace Yandex.Alice.Sdk.Tests.TestsInfrastructure.Collection;

using Xunit;
using Yandex.Alice.Sdk.Tests.TestsInfrastructure.Fixtures;

[CollectionDefinition(TestsConstants.DialogsApiCollectionName)]
public class DialogsApiCollection : ICollectionFixture<DialogsApiFixture>
{
}