using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RepositoryContracts;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace Repository
{
    public class FinnhubRepository : IFinnhubRepository
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;
        public FinnhubRepository(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _httpClient = clientFactory;
            _config = configuration;
        }
        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            using (HttpClient client = _httpClient.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    // https://finnhub.io/api/v1/stock/profile2?symbol={symbol}&token={token}
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_config["token"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
                StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream());
                string? response = streamReader.ReadToEnd();
                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
                return responseDictionary;
            }
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using (HttpClient client = _httpClient.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_config["token"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
                StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream());
                string? response = streamReader.ReadToEnd();
                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
                return responseDictionary;
            }
        }

        public async Task<List<Dictionary<string, string>?>?> GetStocks()
        {
            using(HttpClient client = _httpClient.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/symbol?exchange=US&token={_config["token"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
                StreamReader streamReader = new StreamReader (responseMessage.Content.ReadAsStream());
                string? response = streamReader.ReadToEnd();

                List<Dictionary<string, string>?>? list = JsonSerializer.Deserialize<List<Dictionary<string, string>?>?>(response);
                return list;
            }
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            using(HttpClient client = _httpClient.CreateClient())
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/search?q=apple&token={_config["token"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage httpResponseMessage = await client.SendAsync(message);
                StreamReader streamReader = new StreamReader(httpResponseMessage.Content.ReadAsStream());
                string? response = streamReader.ReadToEnd();
                Dictionary<string,object>? ResponseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>?> (response);
                return ResponseDictionary;
            }    
        }
    }

}