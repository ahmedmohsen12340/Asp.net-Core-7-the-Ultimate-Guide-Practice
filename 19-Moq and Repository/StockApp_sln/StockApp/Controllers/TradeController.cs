﻿using StockApp.ConfigurationOptions;
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
        [Route("[Action]/{stockSymbol?}")]
        public async Task<IActionResult> Index(string stockSymbol)
        {
            if(_tradingOption==null|| _tradingOption.DefaultStockSymbol==null)
            {
                throw new ArgumentNullException(nameof(_tradingOption));
            }
            else
            {
                if(stockSymbol==null)
                {
                    stockSymbol = _tradingOption.DefaultStockSymbol;
                }
                _tradingOption.DefaultStockSymbol = stockSymbol;
                Dictionary<string, object>? companyProfile = await _finnhubService.GetCompanyProfile(stockSymbol ?? throw new ArgumentNullException("stock symbol can't be null"));
                Dictionary<string, object>? companyQuote = await _finnhubService.GetStockPriceQuote(stockSymbol);
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
        public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
        {
            if (ModelState.IsValid)
            {
                await _stocksService.CreateBuyOrder(buyOrderRequest);
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
        public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
        {
            if (ModelState.IsValid)
            {
                await _stocksService.CreateSellOrder(sellOrderRequest);
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
        public async Task<IActionResult> Orders()
         {
                ViewBag.path = "Orders";
                var buyOrders = await _stocksService.GetBuyOrders();
                var buyordersOrdered = buyOrders.OrderByDescending(x => x.DateAndTimeOfOrder).ToList();
                var sellOrders = await _stocksService.GetSellOrders();
                var sellOrdersOrdered = sellOrders.OrderByDescending(x => x.DateAndTimeOfOrder).ToList();
                Orders orders = new Orders() { BuyOrders = buyordersOrdered, SellOrders = sellOrdersOrdered };
                return View(orders);
        }
        [Route("[action]")]
        public async Task<IActionResult> OrdersPDF()
        {
            var buyOrders = await _stocksService.GetBuyOrders();
            var sellorders = await _stocksService.GetSellOrders();
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
