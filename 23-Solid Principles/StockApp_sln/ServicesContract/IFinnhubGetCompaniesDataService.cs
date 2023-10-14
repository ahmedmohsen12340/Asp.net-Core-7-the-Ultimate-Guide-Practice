
namespace ServicesContract
{
    public interface IFinnhubGetCompaniesDataService
    {
        public Task<List<Dictionary<string, string>?>?> GetStocks();
    }
}