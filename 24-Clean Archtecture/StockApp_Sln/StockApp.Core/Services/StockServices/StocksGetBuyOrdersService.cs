using RepositoryContracts;
using ServicesContract;
using ServicesContract.DTO;

namespace Services
{
    public class StocksGetBuyOrdersService : IStocksGetBuyOrdersService
    {
        public readonly IStocksRepository _stocksRepository;

        public StocksGetBuyOrdersService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            /*
                StocksService.GetAllBuyOrders():

                1. When you invoke this method, by default, the returned list should be empty.

                2. When you first add few buy orders using CreateBuyOrder() method; and then invoke GetAllBuyOrders() method; the returned list should contain all the same buy orders.
            */
            var data = await _stocksRepository.GetBuyOrders();
            return data.Select(item => item.ToBuyOrderResponse()).ToList();
        }
    }
}
