using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OnlineTicket.Authorization;

namespace OnlineTicket
{
    [DependsOn(
        typeof(OnlineTicketCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OnlineTicketApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OnlineTicketAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OnlineTicketApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
