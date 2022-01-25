using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineTicket.Students.Dto;
using System.ComponentModel.DataAnnotations;


namespace OnlineTicket.Web.Models.Students
{
    [AutoMapFrom(typeof(StudentDtoOutput))]
    [AutoMapTo(typeof(StudentDtoInput))]
    public class StudentViewModel : EntityDto<int>
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string RegistrationNumber { get; set; }
        [MaxLength(100)]
        public string EmailId { get; set; }
    }
}
