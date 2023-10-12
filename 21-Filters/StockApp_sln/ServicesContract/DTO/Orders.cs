using ServicesContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public List<BuyOrderResponse>? BuyOrders {  get; set; }
        public List<SellOrderResponse>? SellOrders { get; set; }
    }
}
