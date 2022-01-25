using System.Collections.Generic;
using OnlineTicket.Roles.Dto;

namespace OnlineTicket.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}