using System.Collections.Generic;
using OnlineTicket.Students.Dto;

namespace OnlineTicket.Web.Models.Common
{
    public interface IPermissionEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}