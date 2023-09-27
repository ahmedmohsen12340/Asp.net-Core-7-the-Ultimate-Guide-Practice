using ServicesContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface IStocksService
    {
        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest);

        public List<BuyOrderResponse> GetBuyOrders();

        public List<SellOrderResponse> GetSellOrders();
    }
}
