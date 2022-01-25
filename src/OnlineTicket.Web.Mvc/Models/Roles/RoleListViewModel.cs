using System.Collections.Generic;
using OnlineTicket.Roles.Dto;

namespace OnlineTicket.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
