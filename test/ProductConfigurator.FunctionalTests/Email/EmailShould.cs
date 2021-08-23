using FluentAssertions;
using Microsoft.AspNetCore.Http;
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

        //[Fact]
        //public async Task Return_pong_when_ping()
        //{

        //    var response = await Given.Server
        //       .CreateRequest(MailEndpoints.Ping)
        //       .GetAsync();

        //    await response.ShouldBe(StatusCodes.Status200OK);

        //    var result = await response.Content.ReadAsStringAsync();
        //    result.Should().Be("Pong");
        //}
    }
}
