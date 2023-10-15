using Fizzler.Systems.HtmlAgilityPack;
using FluentAssertions;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest_StockApp.IntegrationTests
{
    public class IndexIntegrationTest :IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        public IndexIntegrationTest(CustomWebApplicationFactory customWebApplicationFactory)
        {
            _httpClient = customWebApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task index_ToReturnElementWithPriceClass()
        {
            //arrange
            //act
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("/Trade/Index/MSFT");

            //assert

            httpResponseMessage.Should().BeSuccessful();

            //to get html code in the view as string
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            HtmlDocument html = new HtmlDocument();
            //create html DOM as java script from html string
            html.LoadHtml(responseBody);
            var document = html.DocumentNode;

            document.QuerySelectorAll(".price").Should().NotBeNull();
        }
    }
}
