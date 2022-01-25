using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Authorization;

namespace OnlineTicket.Students.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public string FullName { get; set; }

        public string RegistrationNumber { get; set; }

        public string EmailId { get; set; }
    }
}
