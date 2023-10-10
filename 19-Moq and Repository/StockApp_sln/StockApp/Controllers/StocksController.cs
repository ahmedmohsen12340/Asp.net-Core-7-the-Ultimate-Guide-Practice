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
        private readonly IFinnhubService _finnhubService;
        private readonly TradingOption _tradingOption;

        public StocksController(IFinnhubService finnhubService, IOptions<TradingOption> tradeoption)
        {
            _finnhubService = finnhubService;
            _tradingOption = tradeoption.Value;
        }

        [Route("[action]")]
        public async Task<IActionResult> Explore()
        {
            var allStocks = await _finnhubService.GetStocks();
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


        //[Route("[action]")]
        //public async Task<IActionResult> GetDetails(string companySymbol)
        //{
        //    var companyProfile = await _finnhubService.GetCompanyProfile(companySymbol);
        //    var companyQuote = await _finnhubService.GetStockPriceQuote(companySymbol);
        //    CompanyDetails companyDetails = new CompanyDetails() 
        //    {
        //        StockName = companyProfile?["name"].ToString(),
        //        StockSymbol = companyProfile?["ticker"].ToString(),
        //        StockImage = companyProfile?["logo"].ToString(),
        //        Exchange = companyProfile?["exchange"].ToString(),
        //        Industry = companyProfile?["finnhubIndustry"].ToString(),
        //        Price = Convert.ToDouble(companyQuote?["c"].ToString())
        //    };
        //    return ViewComponent("SelectedStock", companyDetails);
        //}

        [Route("Explore/{StockSymbol}")]
        public async Task<IActionResult> Explore(Stock? stock)
        {
            {
                if(stock==null || stock.StockSymbol == null)
                {
                    return RedirectToAction("Explore");
                }
                    var companyProfile = await _finnhubService.GetCompanyProfile(stock.StockSymbol);
                    var companyQuote = await _finnhubService.GetStockPriceQuote(stock.StockSymbol);
                    CompanyDetails companyDetails = new CompanyDetails()
                    {
                        StockName = companyProfile?["name"].ToString(),
                        StockSymbol = companyProfile?["ticker"].ToString(),
                        StockImage = companyProfile?["logo"].ToString(),
                        Exchange = companyProfile?["exchange"].ToString(),
                        Industry = companyProfile?["finnhubIndustry"].ToString(),
                        Price = Convert.ToDouble(companyQuote?["c"].ToString())
                    };
                    return ViewComponent("SelectedStock", companyDetails);
            }
        }

    }
}
