using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ModelBindingTraining.Validations
{
    public class MyCustomValidationAttribute:ValidationAttribute
    {
        public int minYear { get; set; }
        public MyCustomValidationAttribute()
        {
        }
        public MyCustomValidationAttribute(int MinYear)
        {
            minYear = MinYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= minYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage,minYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            //it means no validation
            return null;
        }
        
    }
}
