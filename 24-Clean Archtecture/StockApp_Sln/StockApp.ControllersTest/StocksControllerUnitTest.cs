using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using ServicesContract;
using StockApp.ConfigurationOptions;
using StockApp.Controllers;

namespace XUnitTest_StockApp.Controllers
{
    public class StocksControllerUnitTest
    {
        private readonly IFixture _fixture;
        private readonly IFinnhubGetCompaniesDataService _FinnhubGetCompaniesDataService;
        private readonly Mock<IFinnhubGetCompaniesDataService> _FinnhubGetCompaniesDataServiceMock;
        public StocksControllerUnitTest()
        {
            _FinnhubGetCompaniesDataServiceMock = new Mock<IFinnhubGetCompaniesDataService>();
            _FinnhubGetCompaniesDataService = _FinnhubGetCompaniesDataServiceMock.Object;
            _fixture = new Fixture();
        }

        [Fact]
        public void Explore_NullStock_TobeExploreView()
        {
            //arrange
            IOptions<TradingOption> options = Options.Create<TradingOption>(new TradingOption() {Top25PopularStocks= "AAPL,MSFT,AMZN,TSLA,GOOGL,GOOG,NVDA,BRK.B,META,UNH,JNJ,JPM,V,PG,XOM,HD,CVX,MA,BAC,ABBV,PFE,AVGO,COST,DIS,KO" });
            StocksController _stocksController = new StocksController(_FinnhubGetCompaniesDataService, options);
            //act
            var actual = _stocksController.Explore(null);

            //assert
            //actual.Should().BeOfType<ViewResult>();
            RedirectToActionResult result = Assert.IsType<RedirectToActionResult>(actual);
            //result.ViewData.Model.Should().BeAssignableTo<IEnumerable<Stock>>();
            result.ActionName.Should().Be("Explore");

        }
    }
}
