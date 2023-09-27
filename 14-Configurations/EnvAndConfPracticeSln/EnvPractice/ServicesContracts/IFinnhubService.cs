namespace EnvPractice.ServicesContracts
{
    public interface IFinnhubService
    {
        public Task<Dictionary<string, object>?> GetStockData(string? stockSymbol);
    }
}
