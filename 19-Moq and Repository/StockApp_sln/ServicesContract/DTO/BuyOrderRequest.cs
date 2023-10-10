using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract.DTO
{
    public class BuyOrderRequest : IValidatableObject
    {
        /*
            string StockSymbol [Mandatory]

            string StockName [Mandatory]

            DateTime DateAndTimeOfOrder [Should not be older than Jan 01, 2000]

            uint Quantity [Value should be between 1 and 100000]

            double Price [Value should be between 1 and 10000]

         */

        [Required(ErrorMessage ="{0} can't be Empty")]
        public string? StockSymbol { get; set; }

        [Required(ErrorMessage = "{0} can't be Empty")]
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }

        [Required(ErrorMessage = "{0} can't be Empty")]
        [Range(1,100000,ErrorMessage = "Value should be between 1 and 100000")]
        public uint? Quantity { get; set; }

        [Range(1, 10000, ErrorMessage = "Value should be between 1 and 10000")]
        public double? Price { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateAndTimeOfOrder?.Year<2000)
            {
                yield return new ValidationResult("the Date of order Should not be older than Jan 01, 2000");
            }
        }
        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder() {BuyOrderID=Guid.NewGuid() , StockSymbol = StockSymbol, StockName = StockName,DateAndTimeOfOrder = DateAndTimeOfOrder, Quantity=Quantity,Price = Price };
        }
    }
}