using Abp.Application.Services;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using OnlineTicket.Students.Dto;

namespace OnlineTicket.Students
{
    public interface IStudentAppService : IApplicationService
    {
        Task<int> CreateAsync(StudentDtoInput input);
        Task<int> Update(StudentDtoInput input);
        Task DeleteAsync(EntityDto<int> input);
        StudentDtoOutput GetDetails(int id);
        IEnumerable<StudentListDto> GetSimpleList();
        IQueryable<StudentListDto> GetSimpleQueryList();
        StudentDtoOutput GetDetails();

    }
}
