using Models;
using RepositoryContracts;
using Services.Helpers;
using ServicesContract;
using ServicesContract.DTO;

namespace Services
{
    public class StocksCreateSellOrderService : IStocksCreateSellOrderService
    {
        public readonly IStocksRepository _stocksRepository;

        public StocksCreateSellOrderService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }
        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
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
            await _stocksRepository.CreateSellOrder(sellOrder);
            var response = sellOrder.ToSellOrderResponse();
            return response;
        }
    }
}
