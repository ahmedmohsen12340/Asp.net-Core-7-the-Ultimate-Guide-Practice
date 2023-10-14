using ServicesContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface IStocksGetBuyOrdersService
    {
        public Task<List<BuyOrderResponse>> GetBuyOrders();
    }
}
