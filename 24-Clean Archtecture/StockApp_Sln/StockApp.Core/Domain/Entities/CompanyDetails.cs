using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CompanyDetails
    {
        public string? StockName {  get; set; }
        public string? StockSymbol { get; set; }
        public string? StockImage { get; set; }
        public double? Price { get; set; }
        public string? Exchange {  get; set; }
        public string? Industry { get; set; }
    }
}
