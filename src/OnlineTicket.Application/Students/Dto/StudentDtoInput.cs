using Abp.Runtime.Validation;
using Abp.AutoMapper;

namespace OnlineTicket.Students.Dto
{
    [AutoMapTo(typeof(Student))]
    [AutoMapFrom(typeof(StudentDtoOutput))]
    public class StudentDtoInput : StudentDtoBase, ICustomValidate
    {
        //Custom validation method. It's called by ABP after data annotation validations.
        public void AddValidationErrors(CustomValidationContext context)
        {
            //add any validation not covered by data annotations
            //context.Results.Add(new ValidationResult("Some Error."));
        }
    }
}
