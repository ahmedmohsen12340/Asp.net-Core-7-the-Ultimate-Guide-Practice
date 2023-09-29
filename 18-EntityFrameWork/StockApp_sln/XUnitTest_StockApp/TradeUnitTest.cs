using Services;
using ServicesContract;
using ServicesContract.DTO;

namespace XUnitTest_StockApp
{
    public class TradeUnitTest
    {
        private readonly IStocksService _stocksService;
        public TradeUnitTest()
        {
            _stocksService = new StockService();
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
        public void CreateBuyOrder_NullBuyOrderRequest()
        {
            //assert
            Assert.Throws<ArgumentNullException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(null);
            });
        }
        [Fact]
        public void CreateBuyOrder_ZeroBuyOrderQuantity()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 0, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(request);
            });
        }
        [Fact]
        public void CreateBuyOrder_OverMaxBuyOrderQuantity()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 100001, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(request);
            });
        }
        [Fact]
        public void CreateBuyOrder_ZeroPrice()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 0 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(request);
            });
        }
        [Fact]
        public void CreateBuyOrder_OverMaxPrice()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 10001 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(request);
            });
        }
        [Fact]
        public void CreateBuyOrder_nullsymbol()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = null, Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(request);
            });
        }
        [Fact]
        public void CreateBuyOrder_OldDate()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("1999-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateBuyOrder(request);
            });
        }
        [Fact]
        public void CreateBuyOrder_Proper()
        {
            //arrange
            BuyOrderRequest request = new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //act
            var x =_stocksService.CreateBuyOrder(request);
            //assert
            Assert.True(x.BuyOrderID!=Guid.Empty);
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
        public void CreateSellOrder_NUllSellOrder()
        {
            //assert
            Assert.Throws<ArgumentNullException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(null);
            });
        }
        [Fact]
        public void CreateSellOrder_ZeroSellOrderQuantity()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 0, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(request);
            });
        }
        [Fact]
        public void CreateSellOrder_OverMaxSellOrderQuantity()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 100001, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(request);
            });
        }
        [Fact]
        public void CreateSellOrder_ZeroPrice()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 0 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(request);
            });
        }
        [Fact]
        public void CreateSellOrder_OverMaxPrice()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 10001 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(request);
            });
        }
        [Fact]
        public void CreateSellOrder_nullsymbol()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = null, Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(request);
            });
        }
        [Fact]
        public void CreateSellOrder_OldDate()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("1999-10-1"), Price = 350 };
            //assert
            Assert.Throws<ArgumentException>( () =>
            {
                //act
                _stocksService.CreateSellOrder(request);
            });
        }
        [Fact]
        public void CreateSellOrder_Proper()
        {
            //arrange
            SellOrderRequest request = new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 };
            //act
            var x = _stocksService.CreateSellOrder(request);
            //assert
            Assert.True(x.SellOrderID != Guid.Empty);
        }

        #endregion

        #region GetAllBuyOrders
        /*
            StocksService.GetAllBuyOrders():

            1. When you invoke this method, by default, the returned list should be empty.

            2. When you first add few buy orders using CreateBuyOrder() method; and then invoke GetAllBuyOrders() method; the returned list should contain all the same buy orders.
        */
        [Fact]
        public void GetBuyOrders_Empty()
        {
            //act
            var x = _stocksService.GetBuyOrders();
            //assert
            Assert.Empty(x);
        }
        [Fact]
        public void GetBuyOrders_proper()
        {
            //arrange
            List<BuyOrderRequest> buyOrderRequests = new List<BuyOrderRequest>()
            {
                 new BuyOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 },
                 new BuyOrderRequest() { StockName = "Alpha", StockSymbol = "GOOG", Quantity = 10, DateAndTimeOfOrder = DateTime.Parse("2020-5-1"), Price = 250 }

            };
            var Expected = buyOrderRequests.Select(buyOrderRequest => _stocksService.CreateBuyOrder(buyOrderRequest)).ToList(); 
            //act
            var actual = _stocksService.GetBuyOrders();
            //assert
            foreach(var x in Expected)
            {
                Assert.Contains(x,actual);
            }
        }

        #endregion
        #region GetAllSellOrders
        /*
            StocksService.GetAllSellOrders():

            1. When you invoke this method, by default, the returned list should be empty.

            2. When you first add few sell orders using CreateSellOrder() method; and then invoke GetAllSellOrders() method; the returned list should contain all the same sell orders.
        */
        [Fact]
        public void GetSellOrders_Empty()
        {
            //act
            var x = _stocksService.GetSellOrders();
            //assert
            Assert.Empty(x);
        }
        [Fact]
        public void GetSellOrders_proper()
        {
            //arrange
            List<SellOrderRequest> sellOrderRequests = new List<SellOrderRequest>()
            {
                 new SellOrderRequest() { StockName = "Apple", StockSymbol = "AAPL", Quantity = 5, DateAndTimeOfOrder = DateTime.Parse("2020-10-1"), Price = 350 },
                 new SellOrderRequest() { StockName = "Alpha", StockSymbol = "GOOG", Quantity = 10, DateAndTimeOfOrder = DateTime.Parse("2020-5-1"), Price = 250 }

            };
            var Expected = sellOrderRequests.Select(sellOrderRequest => _stocksService.CreateSellOrder(sellOrderRequest)).ToList();
            //act
            var actual = _stocksService.GetSellOrders();
            //assert
            foreach (var x in Expected)
            {
                Assert.Contains(x, actual);
            }
        }

        #endregion
    }

}