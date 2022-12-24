using ProductConfigurator.FunctionalTests.Seedwork.Fixture;

namespace ProductConfigurator.FunctionalTests;

public class Given
{
    private readonly ServerFixture serverFixture;

    public Given(ServerFixture serverFixture)
    {
        this.serverFixture = serverFixture;
    }
}
