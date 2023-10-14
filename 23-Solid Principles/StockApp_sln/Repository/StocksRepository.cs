using Microsoft.EntityFrameworkCore;
using Models;
using RepositoryContracts;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StocksRepository : IStocksRepository
    {
        public ApplicationDbContext _db;

        public StocksRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            if (buyOrder == null)
            {
                throw new ArgumentNullException(nameof(buyOrder));
            }
            _db.BuyOrders?.Add(buyOrder);
            await _db.SaveChangesAsync();
            return buyOrder;
        }

        public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        {
            if (sellOrder == null) throw new ArgumentNullException(nameof(sellOrder));
            _db.SellOrders?.Add(sellOrder);
            await _db.SaveChangesAsync();
            return sellOrder;
        }

        public async Task<List<BuyOrder>> GetBuyOrders()
        {
            return await _db.BuyOrders.Select(buyorder => buyorder).ToListAsync();
        }

        public async Task<List<SellOrder>> GetSellOrders()
        {

            return await _db.SellOrders.Select(sellorder => sellorder).ToListAsync();
        }

    }
}
