using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using ServicesContract;
using StockApp.ConfigurationOptions;
using System.Collections.Generic;

namespace StockApp.Controllers
{
    [Route("[controller]")]
    public class StocksController : Controller
    {
        private readonly IFinnhubGetCompaniesDataService _finnhubGetCompaniesDataService;
        private readonly TradingOption _tradingOption;

        public StocksController(IFinnhubGetCompaniesDataService finnhubGetCompaniesDataService, IOptions<TradingOption> tradeoption)
        {
            _finnhubGetCompaniesDataService = finnhubGetCompaniesDataService;
            _tradingOption = tradeoption.Value;
        }

        [Route("[action]")]
        public async Task<IActionResult> Explore()
        {
            var allStocks = await _finnhubGetCompaniesDataService.GetStocks();
            List<string>? top25 = new List<string>();
            var t25 = _tradingOption.Top25PopularStocks?.Split(",");
            top25.AddRange(t25 ?? throw new ArgumentNullException("the top 25 company is empty"));
            List<Dictionary<string, string>?>? final = new List<Dictionary<string, string>?>();
            if (allStocks != null)
            {
                foreach (var itemlist in allStocks)
                {
                    if (itemlist != null && itemlist.ContainsKey("symbol") && top25.Contains(itemlist["symbol"]))
                    {
                        final.Add(itemlist);
                    }
                }
            }
            List<Stock> stocks = new List<Stock>();
            if (allStocks != null)
            {

                foreach (var item in final)
                {
                    stocks.Add(new Stock() { StockName = item?["description"], StockSymbol = item?["symbol"] });
                }
            }
            ViewBag.path = "Explore";
            return View(stocks);
        }

        [Route("Explore/{StockSymbol}")]
        public IActionResult Explore(Stock? stock)
        {
            if(stock==null || stock.StockSymbol == null)
            {
                return RedirectToAction("Explore");
            }
            return ViewComponent("SelectedStock", stock);
        }

    }
}
