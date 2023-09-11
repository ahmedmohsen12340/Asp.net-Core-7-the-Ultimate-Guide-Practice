using System.ComponentModel.DataAnnotations;

namespace Assignment12Redo.Custom_Model_Validations
{
    public class DateValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("you have to submit the year");
            else
            {
                if((value is DateTime x)&&(x.Year>=2000))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("the year must be after 2000");
                }
            }
        }
    }
}
