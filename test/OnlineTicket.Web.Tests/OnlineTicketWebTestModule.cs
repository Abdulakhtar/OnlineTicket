using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineTicket.EntityFrameworkCore;
using OnlineTicket.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace OnlineTicket.Web.Tests
{
    [DependsOn(
        typeof(OnlineTicketWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OnlineTicketWebTestModule : AbpModule
    {
        public OnlineTicketWebTestModule(OnlineTicketEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OnlineTicketWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OnlineTicketWebMvcModule).Assembly);
        }
    }
}