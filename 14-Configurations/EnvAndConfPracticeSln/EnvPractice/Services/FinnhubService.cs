using EnvPractice.ServicesContracts;
using System.Text.Json;

namespace EnvPractice.Services
{
    public class FinnhubService: IFinnhubService

    {
        private readonly IHttpClientFactory? _clintFactory;
        private readonly IConfiguration? _configuration;
        public FinnhubService(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _clintFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<Dictionary<string, object>?> GetStockData(string? stockSymbol)
        {
            using (HttpClient client = _clintFactory.CreateClient())
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration?["token"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);
                Stream stream = httpResponse.Content.ReadAsStream();
                StreamReader reader = new StreamReader(stream);
                string? responce = reader.ReadToEnd();
                Dictionary<string, object>? responceDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responce);
                if (responceDictionary == null || responceDictionary.ContainsKey("Error"))
                {
                    throw new InvalidOperationException("Server doesn't Responce");
                }
                return responceDictionary;
            }
        }
    }
}
