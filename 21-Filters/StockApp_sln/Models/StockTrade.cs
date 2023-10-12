using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StockTrade
    {
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public double? Price { get; set; }
        [Required(ErrorMessage ="{0} From StockTrade Can't be blank")]
        public uint?  Quantity { get; set; }
    }
}