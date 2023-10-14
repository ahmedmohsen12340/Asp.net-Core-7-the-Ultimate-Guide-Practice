
namespace ServicesContract
{
    public interface IFinnhubSearchService
    {
        public Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch);

    }
}