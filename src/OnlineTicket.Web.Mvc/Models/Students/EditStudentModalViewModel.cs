using Abp.AutoMapper;
using OnlineTicket.Students.Dto;
using OnlineTicket.Web.Models.Common;

namespace OnlineTicket.Web.Models.Students
{
    [AutoMapFrom(typeof(GetStudentForEditOutput))]
    public class EditStudentModalViewModel : GetStudentForEditOutput, IPermissionEditViewModel
    {
        //public bool HasPermission(FlatPermissionDto permission)
        //{
        //    return GrantedPermissionNames.Contains(permission.FullName);
        //}
    }
}
