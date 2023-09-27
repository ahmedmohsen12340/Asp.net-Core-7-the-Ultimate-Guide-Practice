using StockApp.ConfigurationOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using ServicesContract;

namespace StockApp.Controllers
{
    public class TradeController : Controller
    {
        private readonly TradingOption _tradingOption;
        private readonly IFinnhubService _finnhubService;
        public TradeController(IOptions<TradingOption> tradingoption,IFinnhubService finnhubService)
        {
            _tradingOption = tradingoption.Value;
            _finnhubService = finnhubService;
        }
        [Route("/")]
        [Route("Trade")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>? companyProfile = await _finnhubService.GetCompanyProfile(_tradingOption.DefaultStockSymbol);
            Dictionary<string,object>? companyQuote = await _finnhubService.GetStockPriceQuote(_tradingOption.DefaultStockSymbol);

            StockTrade stockTrade = new StockTrade() {
                StockName = companyProfile?["name"].ToString(),
                StockSymbol = companyProfile?["ticker"].ToString(),
                Price =Convert.ToDouble(companyQuote?["c"].ToString()),
            };
            return View(stockTrade);
        }
    }
}
