using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Abp.Authorization.Roles;
//using OnlineTicket.Authorization.Roles;

namespace OnlineTicket.Students.Dto
{
    public class CreateStudentDto
    {
        [Required]
        public string FullName { get; set; }
        public string RegistrationNumber { get; set; }
        public string ObtainedMarks { get; set; }
        [Required]
        public string EmailId { get; set; }
        public List<string> GrantedPermissions { get; set; }
    }
}
