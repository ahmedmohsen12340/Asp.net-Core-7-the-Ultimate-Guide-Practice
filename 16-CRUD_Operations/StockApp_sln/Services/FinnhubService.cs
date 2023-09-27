using Microsoft.Extensions.Configuration;
using ServicesContract;
using System.Net.Http;
using System.Text.Json;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;
        public FinnhubService(IHttpClientFactory clientFactory, IConfiguration configuration)
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
            using(HttpClient client = _httpClient.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_config["token"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);
                StreamReader streamReader = new StreamReader(responseMessage.Content.ReadAsStream());
                string? response = streamReader.ReadToEnd();
                Dictionary<string,object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string,object>>(response);
                return responseDictionary;
            }
        }
    }
}