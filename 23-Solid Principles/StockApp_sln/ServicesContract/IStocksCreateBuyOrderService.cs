using ServicesContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{
    public interface IStocksCreateBuyOrderService
    {
        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

    }
}
