using Models;
using Services.Helpers;
using ServicesContract;
using ServicesContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StockService : IStocksService
    {
        public readonly List<BuyOrder> _buyOrders;
        public readonly List<SellOrder> _sellOrders;
        public StockService()
        {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
        }
        public  BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
             /*
                StocksService.CreateBuyOrder():

                1. When you supply BuyOrderRequest as null, it should throw ArgumentNullException.

                2. When you supply buyOrderQuantity as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

                3. When you supply buyOrderQuantity as 100001 (as per the specification, maximum is 100000), it should throw ArgumentException.

                4. When you supply buyOrderPrice as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

                5. When you supply buyOrderPrice as 10001 (as per the specification, maximum is 10000), it should throw ArgumentException.

                6. When you supply stock symbol=null (as per the specification, stock symbol can't be null), it should throw ArgumentException.

                7. When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.

                8. If you supply all valid values, it should be successful and return an object of BuyOrderResponse type with auto-generated BuyOrderID (guid).

            */
            if (buyOrderRequest == null) throw new ArgumentNullException(nameof(buyOrderRequest));
            ValidationHelper.ModelValidation(buyOrderRequest);
            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
            _buyOrders.Add(buyOrder);
            var response = buyOrder.ToBuyOrderResponse();
            return response;
        }

        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            /*
            StocksService.CreateSellOrder():

            1. When you supply SellOrderRequest as null, it should throw ArgumentNullException.

            2. When you supply sellOrderQuantity as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

            3. When you supply sellOrderQuantity as 100001 (as per the specification, maximum is 100000), it should throw ArgumentException.

            4. When you supply sellOrderPrice as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

            5. When you supply sellOrderPrice as 10001 (as per the specification, maximum is 10000), it should throw ArgumentException.

            6. When you supply stock symbol=null (as per the specification, stock symbol can't be null), it should throw ArgumentException.

            7. When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.

            8. If you supply all valid values, it should be successful and return an object of SellOrderResponse type with auto-generated SellOrderID (guid).
            */
            if (sellOrderRequest == null) throw new ArgumentNullException(nameof(sellOrderRequest));
            ValidationHelper.ModelValidation(sellOrderRequest);
            SellOrder sellOrder = sellOrderRequest.ToSellOrder();
            _sellOrders.Add(sellOrder);
            var response = sellOrder.ToSellOrderResponse();
            return response;


        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            /*
                StocksService.GetAllBuyOrders():

                1. When you invoke this method, by default, the returned list should be empty.

                2. When you first add few buy orders using CreateBuyOrder() method; and then invoke GetAllBuyOrders() method; the returned list should contain all the same buy orders.
            */
            return _buyOrders.Select(buyorder=>buyorder.ToBuyOrderResponse()).ToList();
        }

        public List<SellOrderResponse> GetSellOrders()
        {
            /*
                StocksService.GetAllSellOrders():

                1. When you invoke this method, by default, the returned list should be empty.

                2. When you first add few sell orders using CreateSellOrder() method; and then invoke GetAllSellOrders() method; the returned list should contain all the same sell orders.
            */

            return _sellOrders.Select(sellorder => sellorder.ToSellOrderResponse()).ToList();
        }
    }
}
