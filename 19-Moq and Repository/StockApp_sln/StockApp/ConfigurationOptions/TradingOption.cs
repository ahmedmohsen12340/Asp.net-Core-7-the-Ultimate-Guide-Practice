namespace StockApp.ConfigurationOptions
{
    public class TradingOption
    {
        public string? DefaultStockSymbol { get; set; }
        public uint? DefaultOrderQuantity { get; set; }
        public string? Top25PopularStocks { get; set; }
    }
}
