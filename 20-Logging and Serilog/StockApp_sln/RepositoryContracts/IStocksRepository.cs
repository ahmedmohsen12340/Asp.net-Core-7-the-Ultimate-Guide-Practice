using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RepositoryContracts
{
    public interface IStocksRepository
    {
        /*
            Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder);

            Task<SellOrder> CreateSellOrder(SellOrder sellOrder);

            Task<List<BuyOrder>> GetBuyOrders();

            Task<List<SellOrder>> GetSellOrders();
         */

        public Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder);
        public Task<SellOrder> CreateSellOrder(SellOrder sellOrder);
        public Task<List<BuyOrder>> GetBuyOrders();
        public Task<List<SellOrder>> GetSellOrders();
    }
}
