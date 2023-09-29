using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StockMarketDbContext : DbContext
    {
        public StockMarketDbContext(DbContextOptions options):base(options) 
        {

        }
        public DbSet<BuyOrder> BuyOrders { get; set; }

        public DbSet<SellOrder> SellOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyOrder>().ToTable(nameof(BuyOrders));
            modelBuilder.Entity<SellOrder>().ToTable(nameof(SellOrders));
            base.OnModelCreating(modelBuilder);
        }
    }
}
