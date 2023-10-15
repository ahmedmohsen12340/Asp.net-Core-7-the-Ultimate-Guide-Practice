using AutoFixture;
using FluentAssertions;
using Models;
using Moq;
using RepositoryContracts;
using Services;
using ServicesContract;
using ServicesContract.DTO;

namespace XUnitTest_StockApp.Services
{
    public class TradeServiceUnitTest
    {
        private readonly IStocksCreateBuyOrderService _stocksCreateBuyOrderService;
        private readonly IStocksCreateSellOrderService _stocksCreateSellOrderService;
        private readonly IStocksGetBuyOrdersService _stocksGetBuyOrdersService;
        private readonly IStocksGetSellOrdersService _stocksGetSellOrdersService;

        //1-Declare Repository interface 
        private readonly IStocksRepository _stocksRepository;

        //2-Declare Mock</*Repository Interface*/>
        private readonly Mock<IStocksRepository> _stocksRepositoryMock;
        private readonly IFixture _fixture;
        public TradeServiceUnitTest()
        {
            //3-initialize mock object with this object i can mock any method in IStocksRepository
            _stocksRepositoryMock = new Mock<IStocksRepository>();

            //4-initialize Repository class using Mock repository interface to get repository implementation from Mock Object
            _stocksRepository = _stocksRepositoryMock.Object;

            //5-initialize service with repository class to pass repository object to service with mocked functions not the real one
            _stocksCreateBuyOrderService = new StocksCreateBuyOrderService(_stocksRepository);
            _stocksCreateSellOrderService = new StocksCreateSellOrderService(_stocksRepository);
            _stocksGetBuyOrdersService = new StocksGetBuyOrdersService(_stocksRepository);
            _stocksGetSellOrdersService = new StocksGetSellOrdersService(_stocksRepository);
            _fixture = new Fixture();
        }

        #region CreateBuyOrder
        /*
            StocksService.CreateBuyOrder():

            1. When you supply BuyOrderRequest as null, it should throw ArgumentNullException.

            2. When you supply buyOrderQuantity as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

            3. When you supply buyOrderQuantity as 100001 (as per the specification, maximum is 100000), it should throw ArgumentException.

            4. When you supply buyOrderPrice as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

            5. When you supply buyOrderPrice as 10001 (as per the specification, maximum is 10000), it should throw ArgumentException.

            6. When you supply stock symbol=null (as per the specification, stock symbol can't be null), it should throw ArgumentException.

            7. When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.

            8. If you supply all valid values, it should be successful and return an object of BuyOrderResponse type with auto-generated BuyOrderID (guid).
         
         */
        [Fact]
        public async Task CreateBuyOrder_NullBuyOrderRequest_TobeArgumentNullException()
        {

            //assert
            //await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(null);
            //});

            Func<Task> func = async delegate ()
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(null);
            };
            await func.Should().ThrowAsync<ArgumentNullException>();
        }
        [Fact]
        public async Task CreateBuyOrder_ZeroBuyOrderQuantity_TobeArgumentException()
        {
            //arrange
            BuyOrderRequest orderRequest = _fixture.Build<BuyOrderRequest>()
                .With(x => x.Quantity, (uint)0)
                .Create();
            BuyOrder buyOrder = orderRequest.ToBuyOrder();

            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>()))
                .ReturnsAsync(buyOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(orderRequest);
            //});

            Func<Task> func = async () =>
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(orderRequest);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateBuyOrder_OverMaxBuyOrderQuantity_TobeArgumentException()
        {
            //arrange
            BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
                .With(x => x.Quantity, (uint)100001)
                .Create();
            BuyOrder buyOrder = request.ToBuyOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>()))
                .ReturnsAsync(buyOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateBuyOrder_ZeroPrice_TobeArgumentException()
        {
            //arrange
            BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
                .With(x => x.Price, 0)
                .Create();
            BuyOrder buyOrder = request.ToBuyOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>()))
            .ReturnsAsync(buyOrder);
            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateBuyOrder_OverMaxPrice_TobeArgumentException()
        {
            //arrange
            BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
                .With(x => x.Price, 10001)
                .Create();
            BuyOrder buyOrder = request.ToBuyOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>()))
            .ReturnsAsync(buyOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateBuyOrder_Nullsymbol_TobeArgumentException()
        {
            //arrange
            BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
                .With(x => x.StockSymbol, null as string)
                .Create();
            BuyOrder buyOrder = request.ToBuyOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>()))
                .ReturnsAsync(buyOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateBuyOrder_OldDate_TobeArgumentException()
        {
            //arrange
            BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
                .With(x => x.DateAndTimeOfOrder, DateTime.Parse("1999-10-1"))
                .Create();
            ;
            BuyOrder buyOrder = request.ToBuyOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>()))
                .ReturnsAsync(buyOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateBuyOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateBuyOrderService.CreateBuyOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateBuyOrder_ProperPersonData_TobeSucessful()
        {
            //arrange
            BuyOrderRequest request = _fixture.Build<BuyOrderRequest>()
                .With(x => x.DateAndTimeOfOrder, DateTime.Parse("2020-10-1"))
                .Create();
            BuyOrder buyOrder = request.ToBuyOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateBuyOrder(It.IsAny<BuyOrder>())).ReturnsAsync(buyOrder);
            //act
            var actual = await _stocksCreateBuyOrderService.CreateBuyOrder(request);
            //assert
            //Assert.True(actual.BuyOrderID!=Guid.Empty);
            actual.BuyOrderID.Should().NotBeEmpty();

        }
        #endregion

        #region CreateSellOrder

        /*
            StocksService.CreateSellOrder():

            1. When you supply SellOrderRequest as null, it should throw ArgumentNullException.

            2. When you supply sellOrderQuantity as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

            3. When you supply sellOrderQuantity as 100001 (as per the specification, maximum is 100000), it should throw ArgumentException.

            4. When you supply sellOrderPrice as 0 (as per the specification, minimum is 1), it should throw ArgumentException.

            5. When you supply sellOrderPrice as 10001 (as per the specification, maximum is 10000), it should throw ArgumentException.

            6. When you supply stock symbol=null (as per the specification, stock symbol can't be null), it should throw ArgumentException.

            7. When you supply dateAndTimeOfOrder as "1999-12-31" (YYYY-MM-DD) - (as per the specification, it should be equal or newer date than 2000-01-01), it should throw ArgumentException.

            8. If you supply all valid values, it should be successful and return an object of SellOrderResponse type with auto-generated SellOrderID (guid).
         */
        [Fact]
        public async Task CreateSellOrder_NullSellOrder_TobeArgumentNullException()
        {

            //assert
            //await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(null);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(null);
            };
            await func.Should().ThrowAsync<ArgumentNullException>();
        }
        [Fact]
        public async Task CreateSellOrder_ZeroSellOrderQuantity_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.Quantity, (uint)0)
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateSellOrder_OverMaxSellOrderQuantity_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.Quantity, (uint)100001)
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateSellOrder_ZeroPrice_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.Price, 0)
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateSellOrder_OverMaxPrice_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.Price, 10001)
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);


            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateSellOrder_Nullsymbol_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.StockSymbol, null as string)
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateSellOrder_OldDate_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.DateAndTimeOfOrder, DateTime.Parse("1999-10-1"))
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);

            //assert
            //await Assert.ThrowsAsync<ArgumentException>(async () =>
            //{
            //    //act
            //    await _stocksService.CreateSellOrder(request);
            //});
            Func<Task> func = async () =>
            {
                await _stocksCreateSellOrderService.CreateSellOrder(request);
            };
            await func.Should().ThrowAsync<ArgumentException>();
        }
        [Fact]
        public async Task CreateSellOrder_ProperPersonData_TobeArgumentException()
        {
            //arrange
            SellOrderRequest request = _fixture.Build<SellOrderRequest>()
                .With(x => x.DateAndTimeOfOrder, DateTime.Parse("2020-10-1"))
                .Create();

            SellOrder sellOrder = request.ToSellOrder();
            _stocksRepositoryMock.Setup(temp => temp.CreateSellOrder(It.IsAny<SellOrder>()))
                .ReturnsAsync(sellOrder);

            //act
            var actual = await _stocksCreateSellOrderService.CreateSellOrder(request);
            //assert
            //Assert.True(actual.SellOrderID != Guid.Empty);
            actual.SellOrderID.Should().NotBeEmpty();
        }

        #endregion

        #region GetAllBuyOrders
        /*
            StocksService.GetAllBuyOrders():

            1. When you invoke this method, by default, the returned list should be empty.

            2. When you first add few buy orders using CreateBuyOrder() method; and then invoke GetAllBuyOrders() method; the returned list should contain all the same buy orders.
        */
        [Fact]
        public async Task GetBuyOrders_Empty_TobeEmptylist()
        {
            //arrange
            List<BuyOrder> buyOrders = new List<BuyOrder>();
            _stocksRepositoryMock.Setup(temp => temp.GetBuyOrders())
                .ReturnsAsync(buyOrders);

            //act
            var actual = await _stocksGetBuyOrdersService.GetBuyOrders();
            //assert
            //Assert.Empty(actual);
            actual.Should().BeEmpty();
        }
        [Fact]
        public async Task GetBuyOrders_ProperList_TobeSuccessful()
        {
            //arrange
            var buyorders = new List<BuyOrder>()
            {
                _fixture.Create<BuyOrder>(),
                _fixture.Create<BuyOrder>(),
                _fixture.Create<BuyOrder>()
            };
            var expected = new List<BuyOrderResponse>();
            foreach (var item in buyorders)
            {
                expected.Add(item.ToBuyOrderResponse());
            }

            _stocksRepositoryMock.Setup(temp => temp.GetBuyOrders())
                .ReturnsAsync(buyorders);

            //act
            var actual = await _stocksGetBuyOrdersService.GetBuyOrders();
            //assert
            //foreach(var actual in expected)
            //{
            //    Assert.Contains(actual, actual);
            //}
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetAllSellOrders
        /*
            StocksService.GetAllSellOrders():

            1. When you invoke this method, by default, the returned list should be empty.

            2. When you first add few sell orders using CreateSellOrder() method; and then invoke GetAllSellOrders() method; the returned list should contain all the same sell orders.
        */
        [Fact]
        public async Task GetSellOrders_EmptyList_TobeEmpty()
        {
            //arrange
            List<SellOrder> sellOrders = new List<SellOrder>();
            _stocksRepositoryMock.Setup(temp => temp.GetSellOrders())
                .ReturnsAsync(sellOrders);

            //act
            var actual = await _stocksGetSellOrdersService.GetSellOrders();

            //assert
            //Assert.Empty(actual);
            actual.Should().BeEmpty();
        }
        [Fact]
        public async void GetSellOrders_properList_TobeSuccessful()
        {
            //arrange
            var sellorders = new List<SellOrder>()
            {
                _fixture.Create<SellOrder>(),
                _fixture.Create<SellOrder>(),
                _fixture.Create<SellOrder>()
            };
            var expected = new List<SellOrderResponse>();
            foreach (var item in sellorders)
            {
                expected.Add(item.ToSellOrderResponse());
            }

            _stocksRepositoryMock.Setup(temp => temp.GetSellOrders())
                .ReturnsAsync(sellorders);
            //act
            var actual = await _stocksGetSellOrdersService.GetSellOrders();
            //assert
            //foreach (var x in expected)
            //{
            //    Assert.Contains(x, actual);
            //}
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion
    }

}