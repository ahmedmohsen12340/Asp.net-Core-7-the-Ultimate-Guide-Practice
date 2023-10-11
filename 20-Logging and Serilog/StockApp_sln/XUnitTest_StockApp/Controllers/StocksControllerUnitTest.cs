﻿using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Moq;
using ServicesContract;
using StockApp.ConfigurationOptions;
using StockApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest_StockApp.Controllers
{
    public class StocksControllerUnitTest
    {
        private readonly IFixture _fixture;
        private readonly IFinnhubService _finnhubService;
        private readonly Mock<IFinnhubService> _finnhubServiceMock;
        public StocksControllerUnitTest()
        {
            _finnhubServiceMock = new Mock<IFinnhubService>();
            _finnhubService = _finnhubServiceMock.Object;
            _fixture = new Fixture();
        }

        [Fact]
        public async  Task Explore_NullStock_TobeExploreView()
        {
            //arrange
            IOptions<TradingOption> options = Options.Create<TradingOption>(new TradingOption() {Top25PopularStocks= "AAPL,MSFT,AMZN,TSLA,GOOGL,GOOG,NVDA,BRK.B,META,UNH,JNJ,JPM,V,PG,XOM,HD,CVX,MA,BAC,ABBV,PFE,AVGO,COST,DIS,KO" });
            StocksController _stocksController = new StocksController(_finnhubService, options);
            //act
            var actual =await _stocksController.Explore(null);

            //assert
            //actual.Should().BeOfType<ViewResult>();
            RedirectToActionResult result = Assert.IsType<RedirectToActionResult>(actual);
            //result.ViewData.Model.Should().BeAssignableTo<IEnumerable<Stock>>();
            result.ActionName.Should().Be("Explore");

        }
    }
}