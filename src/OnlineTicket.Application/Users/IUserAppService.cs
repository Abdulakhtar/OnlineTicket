using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OnlineTicket.Roles.Dto;
using OnlineTicket.Users.Dto;

namespace OnlineTicket.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
