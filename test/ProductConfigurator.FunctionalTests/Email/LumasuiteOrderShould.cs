using ProductConfigurator.Domain;
using ProductConfigurator.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductConfigurator.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class LumasuiteOrderShould
    {
        private readonly ServerFixture Given;

        public LumasuiteOrderShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        //[Fact]
        //public async Task Be_sent()
        //{

        //    var emailSender = Given.GetService<EmailSender>();
        //    var dto = new OrderRequest()
        //    {
        //        Body = "bodey",
        //        Email = "mail@mail.com",
        //        Name = "my name"
        //    };
                
        //    await emailSender.Send(dto);

        //}
    }
}
