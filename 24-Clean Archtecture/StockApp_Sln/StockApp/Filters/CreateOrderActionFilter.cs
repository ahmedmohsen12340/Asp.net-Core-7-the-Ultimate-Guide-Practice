using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using ServicesContract.DTO;
using StockApp.Controllers;

namespace StockApp.Filters
{
    public class CreateOrderActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<CreateOrderActionFilter> _logger;
        public CreateOrderActionFilter(ILogger<CreateOrderActionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before logic
            _logger.LogInformation("{class}.{method} method", nameof(CreateOrderActionFilter), nameof(OnActionExecutionAsync) + "Before Logic");
            if (context.ActionArguments.ContainsKey("request"))
            {
                object? request = context.ActionArguments["request"];
                TradeController tradeController = (TradeController) context.Controller;
                if(!context.ModelState.IsValid)
                {
                    List<string>? errors = context.ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
                    tradeController.ViewBag.errors = errors;
                    if (request is BuyOrderRequest buyOrderRequest && buyOrderRequest != null)
                    {
                        StockTrade stock = new StockTrade()
                        {
                            StockSymbol = buyOrderRequest.StockSymbol,
                            StockName = buyOrderRequest.StockName,
                            Price = buyOrderRequest.Price,
                            Quantity = buyOrderRequest.Quantity
                        };
                        context.Result = tradeController.View("Index", stock);
                    }
                    if (request is SellOrderRequest sellOrderRequest && sellOrderRequest != null)
                    {
                        StockTrade stock = new StockTrade()
                        {
                            StockSymbol = sellOrderRequest.StockSymbol,
                            StockName = sellOrderRequest.StockName,
                            Price = sellOrderRequest.Price,
                            Quantity = sellOrderRequest.Quantity
                        };
                        context.Result = tradeController.View("Index", stock);
                    }

                }
                else
                {
                    await next(); //to jump to next filter or action method
                }
            }

            //after logic

        }
    }
}
