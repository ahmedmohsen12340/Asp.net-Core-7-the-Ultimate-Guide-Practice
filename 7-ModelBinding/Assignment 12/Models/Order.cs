using Assignment_12.CustomValidations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Assignment_12.Models
{
    public class Order:IValidatableObject
    {
        [BindNever]
        public int? OrderNo { get; set; }
        [Required]
        [DateValidation(ErrorMessage = "Order date should be greater than or equal to 2000-01-01")]
        public DateTime? OrderDate { get; set; }
        [Required]
        public double? InvoicePrice { get; set; }
        [Required]
        public List<Product?> Products { get; set; }
        public Order() 
        {
            Products= new List<Product?>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(validationContext!=null)
            {
      
                double? sum = 0;
                foreach(var product in Products)
                {
                    sum += product.Price * product.Quantity;
                }
                if (sum==InvoicePrice)
                {
                   yield return ValidationResult.Success;
                }
                else
                {
                    yield return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order");
                }
            }
            yield return null;
        }
    }
}
