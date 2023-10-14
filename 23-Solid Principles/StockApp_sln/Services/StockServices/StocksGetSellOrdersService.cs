using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryContracts;
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
    public class StocksGetSellOrdersService : IStocksGetSellOrdersService
    {
        public readonly IStocksRepository _stocksRepository;

        public StocksGetSellOrdersService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }
        public async Task<List<SellOrderResponse>> GetSellOrders()
        {
            /*
                StocksService.GetAllSellOrders():

                1. When you invoke this method, by default, the returned list should be empty.

                2. When you first add few sell orders using CreateSellOrder() method; and then invoke GetAllSellOrders() method; the returned list should contain all the same sell orders.
            */

            var data = await _stocksRepository.GetSellOrders();
            return data.Select(item => item.ToSellOrderResponse()).ToList();
        }
    }
}
