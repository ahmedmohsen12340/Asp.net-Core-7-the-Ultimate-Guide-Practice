using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EnvPractice.Controllers
{
    public class HomeController : Controller
    {
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
        private readonly MyAppOption _config;
        public HomeController(IOptions<MyAppOption> options)
        {
            _config = options.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //MyAppOption x = _config.GetSection("my app").Get<MyAppOption>();
            //ViewBag.config=_config["my app:first"];
            //ViewBag.config = _config.GetValue("my app:second", "HHH");
            //ViewBag.config = _config.GetSection("my app")["second"];
            ViewBag.config = _config.first;
            //ViewData["Env"] = _webHostEnvironment.EnvironmentName;
            return View();
        }
    }
}
