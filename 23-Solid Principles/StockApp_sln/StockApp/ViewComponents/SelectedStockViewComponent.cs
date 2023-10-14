using Microsoft.AspNetCore.Mvc;
using Models;
using ServicesContract;

namespace StockApp.ViewComponents
{
    public class SelectedStockViewComponent:ViewComponent
    {
        private readonly IFinnhubGetDetailsService _finnhubGetDetailsService;
        public SelectedStockViewComponent(IFinnhubGetDetailsService finnhubGetDetailsService)
        {
            _finnhubGetDetailsService = finnhubGetDetailsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Stock stock)
        {
            var companyProfile = await _finnhubGetDetailsService.GetCompanyProfile(stock.StockSymbol??throw new ArgumentNullException("stocksymbol is null here"));
            var companyQuote = await _finnhubGetDetailsService.GetStockPriceQuote(stock.StockSymbol);
            CompanyDetails companyDetails = new CompanyDetails()
            {
                StockName = companyProfile?["name"].ToString(),
                StockSymbol = companyProfile?["ticker"].ToString(),
                StockImage = companyProfile?["logo"].ToString(),
                Exchange = companyProfile?["exchange"].ToString(),
                Industry = companyProfile?["finnhubIndustry"].ToString(),
                Price = Convert.ToDouble(companyQuote?["c"].ToString())
            };

            return View("StockDetails",companyDetails);
        }
    }
}
