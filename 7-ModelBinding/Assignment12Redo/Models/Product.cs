using System.ComponentModel.DataAnnotations;

namespace Assignment12Redo.Models
{
    public class Product
    {
        [RegularExpression("\\d+",ErrorMessage ="product code should be int only")]
        public int? ProductCode {  get; set; }
        [RegularExpression("\\d+", ErrorMessage = "Price should be int only")]
        public double? Price { get; set; }
        [RegularExpression("\\d+", ErrorMessage = "quantity code should be int only")]
        public int? Quantity { get; set; }
    }
}
