using System.Threading.Tasks;
using Abp.Application.Services;
using OnlineTicket.Sessions.Dto;

namespace OnlineTicket.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
