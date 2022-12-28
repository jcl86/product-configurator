using ProductConfigurator.FunctionalTests.Seedwork.Fixture;

using Xunit;

namespace ProductConfigurator.FunctionalTests;

[Collection(nameof(ServerFixtureCollection))]
public class EmailShould
{
    private readonly ServerFixture Given;

    public EmailShould(ServerFixture fixture)
    {
        Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    //[Fact(Skip ="Not send")]
    //public async Task Send_email()
    //{
    //    var emailSender = Given.GetService<SendgridEmailSender>();
    //    await emailSender.SendPlainBody("jorgeaadlab@gmail.com", "prueba", "prueba body");

    //}
}
