using Microsoft.Extensions.Configuration;
using RepositoryContracts;
using ServicesContract;
using System.Net.Http;
using System.Text.Json;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IFinnhubRepository _finnhubRepository;
        public FinnhubService(IHttpClientFactory clientFactory, IFinnhubRepository finnhubRepository)
        {
            _httpClient = clientFactory;
            _finnhubRepository = finnhubRepository;
        }
        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            using (HttpClient client = _httpClient.CreateClient())
            {
                return await _finnhubRepository.GetCompanyProfile(stockSymbol);
            }
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using(HttpClient client = _httpClient.CreateClient())
            {
                return await _finnhubRepository.GetStockPriceQuote(stockSymbol);
            }
        }

        public async Task<List<Dictionary<string, string>?>?> GetStocks()
        {
            return await _finnhubRepository.GetStocks();
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            return await _finnhubRepository.SearchStocks(stockSymbolToSearch);
        }
    }
}