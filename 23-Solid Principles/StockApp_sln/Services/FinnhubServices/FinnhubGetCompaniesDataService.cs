using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServicesContract;
using System.Net.Http;
using System.Text.Json;

namespace Services
{
    public class FinnhubGetCompaniesDataService : IFinnhubGetCompaniesDataService
    {
        private readonly IFinnhubRepository _finnhubRepository;
        public FinnhubGetCompaniesDataService(IFinnhubRepository finnhubRepository)
        {
            _finnhubRepository = finnhubRepository;
        }
        public async Task<List<Dictionary<string, string>?>?> GetStocks()
        {
            return await _finnhubRepository.GetStocks();
        }
    }
}