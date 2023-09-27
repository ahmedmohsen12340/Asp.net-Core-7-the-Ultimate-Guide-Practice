using Microsoft.AspNetCore.Mvc;

namespace XunitExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
