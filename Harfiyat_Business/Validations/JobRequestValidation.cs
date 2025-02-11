using FluentValidation;
using Harfiyat_Entities.Entities;

namespace Harfiyat_Business.Validations;

public class JobRequestValidation : AbstractValidator<JobRequest>
{
    public JobRequestValidation()
    {
        RuleFor(x=>x.JobTitle)
            .MinimumLength(3)
            .MaximumLength(500)
            .NotNull();
    }
}
