using System.Collections.Generic;
using OnlineTicket.Roles.Dto;

namespace OnlineTicket.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
