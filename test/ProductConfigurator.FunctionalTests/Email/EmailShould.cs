using FluentAssertions;
using Microsoft.AspNetCore.Http;
using ProductConfigurator.Api;
using ProductConfigurator.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductConfigurator.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class EmailShould
    {
        private readonly ServerFixture Given;

        public EmailShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Ping()
        {

            var response = await Given.Server
               .CreateRequest(MailEndpoints.Ping)
               .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);

            var result = await response.Content.ReadAsStringAsync();
            result.Should().Be("Pong");
        }

        [Fact(Skip ="Not send")]
        public async Task Send_email()
        {
            var emailSender = Given.GetService<SendgridEmailSender>();
            await emailSender.SendPlainBody("jorgeaadlab@gmail.com", "prueba", "prueba body");

        }
    }
}
