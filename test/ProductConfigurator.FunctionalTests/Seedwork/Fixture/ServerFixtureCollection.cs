using Xunit;

namespace ProductConfigurator.FunctionalTests.Seedwork.Fixture;

[CollectionDefinition(nameof(ServerFixtureCollection))]
public class ServerFixtureCollection : ICollectionFixture<ServerFixture>
{
}
