using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineTicket.Configuration;

namespace OnlineTicket.Web.Host.Startup
{
    [DependsOn(
       typeof(OnlineTicketWebCoreModule))]
    public class OnlineTicketWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OnlineTicketWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineTicketWebHostModule).GetAssembly());
        }
    }
}
