using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract.DTO
{
    public class BuyOrderResponse
    {
        /*
            Guid BuyOrderID

            string StockSymbol

            string StockName

            DateTime DateAndTimeOfOrder

            uint Quantity

            double Price

            double TradeAmount
         */

        public Guid? BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }
        public uint? Quantity { get; set; }
        public double? Price { get; set; }
        public double? TradeAmount { get; set; }
        public override bool Equals(object? obj)
        {
            if ((obj is BuyOrderResponse buy) && (buy != null))
            {
                return (buy.BuyOrderID.Equals(BuyOrderID)) && (string.Equals(buy.StockSymbol,StockSymbol,StringComparison.Ordinal) && (string.Equals(buy.StockName, StockName, StringComparison.Ordinal) && buy.DateAndTimeOfOrder.Equals(DateAndTimeOfOrder) && (buy.Quantity.Equals(Quantity)) && (buy.Price.Equals(Price))));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class BuyExtensionsMethods
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse()
            {   
                BuyOrderID = buyOrder.BuyOrderID,
                StockSymbol = buyOrder.StockSymbol,
                StockName = buyOrder.StockName,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity,
                Price = buyOrder.Price,
                TradeAmount =  buyOrder.Price * buyOrder.Quantity
            };
        }
    }
}
