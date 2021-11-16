using Xunit;

namespace MundoBalloonApi.test.Fixtures;

[CollectionDefinition("WithDatabase")]
public class WithDatabaseCollection : ICollectionFixture<RepositoriesFixture>
{
}