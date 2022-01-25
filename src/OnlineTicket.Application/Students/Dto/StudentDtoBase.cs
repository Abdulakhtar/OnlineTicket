using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace OnlineTicket.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentDtoBase : EntityDto<int>
    {
        public string FullName { get; set; }
        public string RegistrationNumber { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }

    }
}
