using FluentAssertions;

using Microsoft.AspNetCore.Http;
using ProductConfigurator.FunctionalTests.Seedwork.Fixture;
using ProductConfigurator.Domain;

using Xunit;
using ProductConfigurator.Shared;

namespace ProductConfigurator.FunctionalTests;

[Collection(nameof(ServerFixtureCollection))]
public class ApiShould
{
    private readonly ServerFixture given;

    public ApiShould(ServerFixture fixture)
    {
        given = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task be_healthy()
    {
        HttpResponseMessage response = await given.Server
           .CreateRequest(Endpoints.Health)
           .GetAsync();

        await response.ShouldBe(StatusCodes.Status200OK);

        string result = await response.Content.ReadAsStringAsync();
        result.Should().BeEmpty();
    }

    //[Fact(Skip ="Not send")]
    //public async Task Send_email()
    //{
    //    var emailSender = Given.GetService<SendgridEmailSender>();
    //    await emailSender.SendPlainBody("jorgeaadlab@gmail.com", "prueba", "prueba body");

    //}
}
