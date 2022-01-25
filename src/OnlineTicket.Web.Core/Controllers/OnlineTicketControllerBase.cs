using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace OnlineTicket.Controllers
{
    public abstract class OnlineTicketControllerBase: AbpController
    {
        protected OnlineTicketControllerBase()
        {
            LocalizationSourceName = OnlineTicketConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
