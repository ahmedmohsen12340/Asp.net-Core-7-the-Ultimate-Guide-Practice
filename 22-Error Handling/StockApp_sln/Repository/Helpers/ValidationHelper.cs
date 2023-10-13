using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    internal class ValidationHelper
    {
        public static void ModelValidation(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext,validationResults,true);
            if (!isValid)
            {
                var x =validationResults.Select(result =>result.ErrorMessage);
                foreach(var error in x)
                {
                    throw new ArgumentException(error);
                }
            }
        }
    }
}
