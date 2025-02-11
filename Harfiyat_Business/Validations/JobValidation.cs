using FluentValidation;
using Harfiyat_Entities.Entities;

namespace Harfiyat_Business.Validations;

public class JobValidation : AbstractValidator<Job>
{
    public JobValidation()
    {
      RuleFor(x=>x.ProjectName).NotEmpty().NotNull();  
    }
}
