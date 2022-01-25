using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using OnlineTicket.Controllers;

namespace OnlineTicket.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : OnlineTicketControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
