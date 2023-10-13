using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FinnhubService> _logger;
        public FinnhubService(IHttpClientFactory clientFactory, IFinnhubRepository finnhubRepository,ILogger<FinnhubService> logger)
        {
            _httpClient = clientFactory;
            _finnhubRepository = finnhubRepository;
            _logger = logger;
        }
        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            _logger.LogInformation("start get company profile");
            using (HttpClient client = _httpClient.CreateClient())
            {
                return await _finnhubRepository.GetCompanyProfile(stockSymbol);
            }
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            _logger.LogInformation("start get stock price quote");
            using (HttpClient client = _httpClient.CreateClient())
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