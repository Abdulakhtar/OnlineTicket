using Abp.AspNetCore.Mvc.ViewComponents;

namespace OnlineTicket.Web.Views
{
    public abstract class OnlineTicketViewComponent : AbpViewComponent
    {
        protected OnlineTicketViewComponent()
        {
            LocalizationSourceName = OnlineTicketConsts.LocalizationSourceName;
        }
    }
}
