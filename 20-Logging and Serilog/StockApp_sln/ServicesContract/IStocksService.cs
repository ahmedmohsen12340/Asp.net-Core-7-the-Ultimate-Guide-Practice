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
        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);

        public Task<List<BuyOrderResponse>> GetBuyOrders();

        public Task<List<SellOrderResponse>> GetSellOrders();
    }
}
