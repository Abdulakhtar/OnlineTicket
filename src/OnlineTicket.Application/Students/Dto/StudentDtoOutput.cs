using Abp.Domain.Entities.Auditing;
using System;
using Abp.AutoMapper;

namespace OnlineTicket.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentDtoOutput : StudentDtoBase, IAudited
    {
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        
    }
}
