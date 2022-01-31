using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
//using Abp.Authorization.Students;
//using OnlineTicket.Authorization.Students;

namespace OnlineTicket.Students.Dto
{
    public class StudentEditDto: EntityDto<int>
    {
        [Required]
        public string FullName { get; set; }
        public string RegistrationNumber { get; set; }
        public string ObtainedMarks { get; set; }
        [Required]
        public string EmailId { get; set; }
        public bool IsStatic { get; set; }
    }
}