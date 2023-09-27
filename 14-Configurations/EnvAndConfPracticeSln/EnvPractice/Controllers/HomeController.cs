using EnvPractice.Model;
using EnvPractice.ServicesContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EnvPractice.Controllers
{
    public class HomeController : Controller
    {
        #region environment
        //private readonly IWebHostEnvironment _webHostEnvironment;
        //public HomeController(IWebHostEnvironment webHostEnvironment)
        //{
        //    _webHostEnvironment = webHostEnvironment;
        //}
        //private readonly IConfiguration _config;
        //public HomeController(IConfiguration configuration)
        //{
        //    _config = configuration;
        //}
        //private readonly MyAppOption _config;
        //public HomeController(IOptions<MyAppOption> options)
        //{
        //    _config = options.Value;
        //}
        #endregion

        private readonly IFinnhubService? _finnhub;
        public HomeController(IFinnhubService finnhub)
        {
            _finnhub = finnhub;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            #region environment
            //MyAppOption x = _config.GetSection("my app").Get<MyAppOption>();
            //ViewBag.config=_config["my app:first"];
            //ViewBag.config = _config.GetValue("my app:second", "HHH");
            //ViewBag.config = _config.GetSection("my app")["second"];
            //ViewBag.config = _config.first;
            //ViewData["Env"] = _webHostEnvironment.EnvironmentName;
            #endregion
            Dictionary<string,object>? x = await _finnhub?.GetStockData("AAPL");
            StockData stockData = new StockData() { CurrentPrice = Convert.ToDouble(x?["c"].ToString()) };



            return View(stockData);
        }
    }
}
