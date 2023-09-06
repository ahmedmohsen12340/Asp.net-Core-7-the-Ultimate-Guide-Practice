using System.ComponentModel.DataAnnotations;

namespace Assignment_12.CustomValidations
{
    public class DateValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? date = value as DateTime?;
                if (date.Value.Year < 2000)
                {
                    return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
