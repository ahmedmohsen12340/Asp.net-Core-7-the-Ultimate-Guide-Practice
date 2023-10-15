using Models;
using RepositoryContracts;
using Services.Helpers;
using ServicesContract;
using ServicesContract.DTO;

namespace Services
{
    public class StocksCreateBuyOrderService : IStocksCreateBuyOrderService
    {
        public readonly IStocksRepository _stocksRepository;

        public StocksCreateBuyOrderService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }
        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
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
            await _stocksRepository.CreateBuyOrder(buyOrder);
            var response = buyOrder.ToBuyOrderResponse();
            return response;
        }

    }
}
