using Abp.AutoMapper;
using Abp.Application.Services.Dto;

namespace OnlineTicket.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    [AutoMapTo(typeof(StudentDtoInput))]
    public class StudentListDto : AuditedEntityDto<int>
    {
        public string FullName { get; set; }
        public string RegistrationNumber { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}
