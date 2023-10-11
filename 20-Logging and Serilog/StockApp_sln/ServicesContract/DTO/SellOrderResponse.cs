using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract.DTO
{
    public class SellOrderResponse
    {
        /*
            Guid SellOrderID

            string StockSymbol

            string StockName

            DateTime DateAndTimeOfOrder

            uint Quantity

            double Price

            double TradeAmount
         */
        public Guid? SellOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }
        public uint? Quantity { get; set; }
        public double? Price { get; set; }
        public double? TradeAmount { get; set; }
        public override bool Equals(object? obj)
        {
            if ((obj is SellOrderResponse buy) && (buy != null))
            {
                return (buy.SellOrderID.Equals(SellOrderID)) && (string.Equals(buy.StockSymbol, StockSymbol, StringComparison.Ordinal) && (string.Equals(buy.StockName, StockName, StringComparison.Ordinal) && buy.DateAndTimeOfOrder.Equals(DateAndTimeOfOrder) && (buy.Quantity.Equals(Quantity)) && (buy.Price.Equals(Price))));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
    public static class SellExtensionsMethods
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                SellOrderID = sellOrder.SellOrderID,
                StockSymbol = sellOrder.StockSymbol,
                StockName = sellOrder.StockName,
                DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
                Quantity = sellOrder.Quantity,
                Price = sellOrder.Price,
                TradeAmount = sellOrder.Price * sellOrder.Quantity
            };
        }
    }

}
