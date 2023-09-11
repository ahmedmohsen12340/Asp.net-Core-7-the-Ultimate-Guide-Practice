using Assignment12Redo.Custom_Model_Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Assignment12Redo.Models
{
    public class Order:IValidatableObject
    {
        [BindNever]
        public int? OrderNo { get; set; } = new Random().Next(1,99999);
        [DateValidation]
        public DateTime? OrderDate { get; set; }
        [Required]
        [RegularExpression("\\d+", ErrorMessage = "Invoice price should be int only")]
        public double InvoicePrice { get; set; }
        [Required(ErrorMessage ="you have to order at least one product",AllowEmptyStrings =false)]
        public List<Product> Products { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Products.Count > 0)
            {
                double? sum = 0;
                foreach (var product in Products)
                {
                    sum += product?.Price*product?.Quantity;
                }
                if (InvoicePrice == sum)
                    yield return ValidationResult.Success;
                else
                {
                    yield return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order.");
                }
            }
            yield return null;
        }
        
    }
}
