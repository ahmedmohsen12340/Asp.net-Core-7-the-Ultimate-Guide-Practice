
namespace ServicesContract
{
    public interface IFinnhubGetDetailsService
    {
        public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
        public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);

    }
}