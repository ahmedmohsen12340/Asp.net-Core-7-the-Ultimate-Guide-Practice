using StockApp.ConfigurationOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using ServicesContract;
using ServicesContract.DTO;
using Rotativa.AspNetCore;

namespace StockApp.Controllers
{
    [Route("[Controller]")]
    public class TradeController : Controller
    {
        private readonly TradingOption _tradingOption;
        private readonly IFinnhubService _finnhubService;
        private readonly IStocksService _stocksService;
        public TradeController(IOptions<TradingOption> tradingoption,IFinnhubService finnhubService, IStocksService stocksService)
        {
            _tradingOption = tradingoption.Value;
            _finnhubService = finnhubService;
            _stocksService = stocksService;
        }
        [Route("/")]
        [Route("[Action]")]
        public async Task<IActionResult> Index()
        {
            if(_tradingOption==null|| _tradingOption.DefaultStockSymbol==null)
            {
                throw new ArgumentNullException(nameof(_tradingOption));
            }
            else
            {
                Dictionary<string, object>? companyProfile = await _finnhubService.GetCompanyProfile(_tradingOption.DefaultStockSymbol);
                Dictionary<string, object>? companyQuote = await _finnhubService.GetStockPriceQuote(_tradingOption.DefaultStockSymbol);
                StockTrade stockTrade = new StockTrade()
                {
                    StockName = companyProfile?["name"].ToString(),
                    StockSymbol = companyProfile?["ticker"].ToString(),
                    Price = Convert.ToDouble(companyQuote?["c"].ToString()),
                    Quantity = _tradingOption.DefaultOrderQuantity
                };
                ViewBag.path = "Index";
                //ViewBag.errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                return View(stockTrade);
            }
        }
        //Trade/BuyOrder
        [Route("[action]")]
        public IActionResult BuyOrder(BuyOrderRequest buyOrderRequest)
        {
            if (ModelState.IsValid)
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
                return RedirectToAction("Orders");
            }
            else
            {
                ViewBag.errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                StockTrade stock = new StockTrade()
                {
                    StockSymbol = buyOrderRequest.StockSymbol,
                    StockName = buyOrderRequest.StockName,
                    Price = buyOrderRequest.Price,
                    Quantity = buyOrderRequest.Quantity
                };
                return View("Index",stock);
            }
        }
        [Route("[action]")]
        public IActionResult SellOrder(SellOrderRequest sellOrderRequest)
        {
            if (ModelState.IsValid)
            {
                _stocksService.CreateSellOrder(sellOrderRequest);
                return RedirectToAction("Orders");
            }
            else
            {
                ViewBag.errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                StockTrade stock = new StockTrade()
                {
                    StockSymbol = sellOrderRequest.StockSymbol,
                    StockName = sellOrderRequest.StockName,
                    Price = sellOrderRequest.Price,
                    Quantity = sellOrderRequest.Quantity
                };
                return View("Index", stock);
            }
        }
        [Route("[action]")]
        public IActionResult Orders()
         {
                ViewBag.path = "Orders";
                var buyOrders = _stocksService?.GetBuyOrders();
                var sellorders = _stocksService?.GetSellOrders();
                Orders orders = new Orders() { BuyOrders = buyOrders, SellOrders = sellorders };
                return View(orders);
        }
        [Route("[action]")]
        public IActionResult OrdersPDF()
        {
            var buyOrders = _stocksService?.GetBuyOrders();
            var sellorders = _stocksService?.GetSellOrders();
            Orders orders = new Orders() { BuyOrders = buyOrders, SellOrders = sellorders };
            return new ViewAsPdf(orders, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top = 20,
                    Right = 20,
                    Left = 20,
                    Bottom = 20
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }
    }
}
