using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using Serilog;
using ServicesContract;
using System.Net.Http;
using System.Text.Json;

namespace Services
{
    public class FinnhubGetDetailsService : IFinnhubGetDetailsService
    {
        private readonly IFinnhubRepository _finnhubRepository;
        private readonly ILogger<FinnhubGetDetailsService> _logger;
        public FinnhubGetDetailsService(IFinnhubRepository finnhubRepository,ILogger<FinnhubGetDetailsService> logger)
        {
            _finnhubRepository = finnhubRepository;
            _logger = logger;
        }
        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            _logger.LogInformation("start get company profile");
            return await _finnhubRepository.GetCompanyProfile(stockSymbol);
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            _logger.LogInformation("start get stock price quote");
            return await _finnhubRepository.GetStockPriceQuote(stockSymbol);
        }
    }
}