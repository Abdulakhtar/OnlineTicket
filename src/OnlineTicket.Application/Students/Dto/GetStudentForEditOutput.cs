using System.Collections.Generic;

namespace OnlineTicket.Students.Dto
{
    public class GetStudentForEditOutput
    {
        public StudentEditDto Student { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}