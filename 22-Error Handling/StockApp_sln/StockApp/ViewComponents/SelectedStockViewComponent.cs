using Microsoft.AspNetCore.Mvc;
using Models;
using ServicesContract;

namespace StockApp.ViewComponents
{
    public class SelectedStockViewComponent:ViewComponent
    {
        private readonly IFinnhubService _finnhubService;
        public SelectedStockViewComponent(IFinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Stock stock)
        {
            var companyProfile = await _finnhubService.GetCompanyProfile(stock.StockSymbol??throw new ArgumentNullException("stocksymbol is null here"));
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

            return View("StockDetails",companyDetails);
        }
    }
}
