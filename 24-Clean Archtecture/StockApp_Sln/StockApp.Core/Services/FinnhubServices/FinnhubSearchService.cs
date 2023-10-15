using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServicesContract;
using System.Net.Http;
using System.Text.Json;

namespace Services
{
    public class FinnhubSearchService : IFinnhubSearchService
    {
        private readonly IFinnhubRepository _finnhubRepository;
        public FinnhubSearchService(IFinnhubRepository finnhubRepository)
        {
            _finnhubRepository = finnhubRepository;
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            return await _finnhubRepository.SearchStocks(stockSymbolToSearch);
        }
    }
}