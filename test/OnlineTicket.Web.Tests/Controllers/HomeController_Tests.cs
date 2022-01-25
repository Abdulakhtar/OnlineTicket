using System.Threading.Tasks;
using OnlineTicket.Models.TokenAuth;
using OnlineTicket.Web.Controllers;
using Shouldly;
using Xunit;

namespace OnlineTicket.Web.Tests.Controllers
{
    public class HomeController_Tests: OnlineTicketWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}