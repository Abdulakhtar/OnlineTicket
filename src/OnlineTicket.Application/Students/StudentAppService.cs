using System.Collections.Generic;
using Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Application.Services.Dto;
using OnlineTicket.Students.Dto;

namespace OnlineTicket.Students
{
    public class StudentAppService : OnlineTicketAppServiceBase, IStudentAppService
    {
        public readonly IRepository<Student, int> _repository;

        public StudentAppService(IRepository<Student, int> repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(StudentDtoInput input)
        {
            Student entity = ObjectMapper.Map<Student>(input);
            await _repository.InsertAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Update(StudentDtoInput input)
        {
            try
            {
                Student entity = await _repository.GetAsync(input.Id);
                ObjectMapper.Map(input, entity);
                await _repository.UpdateAsync(entity);
                await UnitOfWorkManager.Current.SaveChangesAsync();
                return entity.Id;
            }
            catch (System.Exception e)
            {
                throw e;
            }
          
        }

        public async Task DeleteAsync(EntityDto<int> input)
        {
            await _repository.DeleteAsync(await _repository.GetAsync(input.Id));
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public  StudentDtoOutput GetDetails(int id)
        {
            return ObjectMapper.Map<StudentDtoOutput>(_repository.Get(id));
        }

        public StudentDtoOutput GetDetails()
        {
            return ObjectMapper.Map<StudentDtoOutput>(_repository.GetAll().FirstOrDefault());
        }

        public IEnumerable<StudentListDto> GetSimpleList()
        {
            return ObjectMapper.Map<IEnumerable<StudentListDto>>(_repository.GetAll());
        }

        public IQueryable<StudentListDto> GetSimpleQueryList()
        {
            return ObjectMapper.ProjectTo<StudentListDto>(_repository.GetAll());
        }

        public List<StudentDtoOutput> GetAll()
        {
            return ObjectMapper.Map<List<StudentDtoOutput>>(_repository.GetAll());
        }
    }
}