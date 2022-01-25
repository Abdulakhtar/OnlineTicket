using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace OnlineTicket.Web.Views
{
    public abstract class OnlineTicketRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected OnlineTicketRazorPage()
        {
            LocalizationSourceName = OnlineTicketConsts.LocalizationSourceName;
        }
    }
}
