using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BuyOrder
    {
        /*
            Guid BuyOrderID

            string StockSymbol [Mandatory]

            string StockName [Mandatory]

            DateTime DateAndTimeOfOrder

            uint Quantity [Value should be between 1 and 100000]

            double Price [Value should be between 1 and 10000]
         
         */
        public Guid? BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set;}
        public DateTime? DateAndTimeOfOrder { get; set; }
        public uint? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
