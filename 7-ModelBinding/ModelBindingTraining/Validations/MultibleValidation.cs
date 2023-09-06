using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBindingTraining.Validations
{
    public class MultibleValidationAttribute:ValidationAttribute
    {
        public string OtherProperty {  get; set; }
        public MultibleValidationAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime todate = (DateTime)value;
                var otherPropertyName = validationContext.ObjectType.GetProperty(OtherProperty);
                DateTime fromdate = (DateTime)otherPropertyName.GetValue(validationContext.ObjectInstance);
                if(fromdate>todate) 
                {
                    return new ValidationResult(ErrorMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
