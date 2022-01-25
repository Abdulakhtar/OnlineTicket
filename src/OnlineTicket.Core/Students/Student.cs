using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace OnlineTicket.Students
{
    [Table("StudentData")]
    public class Student : FullAuditedEntity<int>, IPassivable
    {
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string RegistrationNumber { get; set; }
        [MaxLength(256)]
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}
