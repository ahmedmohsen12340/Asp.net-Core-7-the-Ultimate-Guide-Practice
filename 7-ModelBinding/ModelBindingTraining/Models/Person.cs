using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using ModelBindingTraining.Validations;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace ModelBindingTraining.Models
{
    public class Person/*:IValidatableObject*/
    {
        [Required(ErrorMessage ="id is mandtory")]
        public int? Id { get; set; }
        [StringLength(50,MinimumLength =2,ErrorMessage ="{0} name should have min length of {2} and max lenght of {1}")]
        [Display(Name ="Employee")]
        public string? Name { get; set; }
        //[Required(ErrorMessage ="{0} is mandtory")]
        [Range(25,65,ErrorMessage ="{0} must be between {1}:{2}")]
        public int? age { get; set; }
        [Phone]
        public string? phone { get; set; }
        [ValidateNever]
        [EmailAddress]
        public string? Email { get; set; }
        public string? password { get; set; }
        [Compare("password")]
        public string? confirmPassword { get; set; }
        [MyCustomValidation(minYear =2003,ErrorMessage = "the year must be {0} or less")]
        public DateTime? dateTime { get; set; }
        public DateTime? FromDate { get; set; }
        [MultibleValidation("FromDate",ErrorMessage ="to-date can't be earlier than from-date")]
        public DateTime? ToDate { get; set; }
        public override string ToString()
        {
            return $"the Employee Name is: {Name} ,and Employee Id is:{Id} .";
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(dateTime == null && age == null)
        //    {
        //        yield return new ValidationResult("you have to submit one of those Age or dateTime");
        //    }
        //    else
        //    {
        //        yield return ValidationResult.Success;
        //    }
        //}
    }
}
