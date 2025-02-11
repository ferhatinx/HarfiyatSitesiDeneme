using FluentValidation.Results;
using Harfiyat_Common.ResponseObjects;

namespace Harfiyat_Business.Extensions;

public static class ConverToFluenValidationResult
{
    public static List<CustomValidationError> ConvertToFluentValidatonResultErrors(this ValidationResult result)
    {
        var customErrors = new List<CustomValidationError>();
        foreach (ValidationFailure error in result.Errors)
        {
            customErrors.Add(new CustomValidationError(error.PropertyName,error.ErrorMessage));
        }
        return customErrors;
    }

}
