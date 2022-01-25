using Abp.Application.Services;
using OnlineTicket.MultiTenancy.Dto;

namespace OnlineTicket.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

