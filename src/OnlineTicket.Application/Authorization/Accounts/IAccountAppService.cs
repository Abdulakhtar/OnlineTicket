using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineTicket.Authorization.Accounts.Dto;

namespace OnlineTicket.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
