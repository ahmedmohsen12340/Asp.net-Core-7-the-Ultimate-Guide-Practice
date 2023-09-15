using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Assignment24.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialMediaOption? _socialMedia;
        public HomeController(IOptions<SocialMediaOption> x)
        {
            _socialMedia = x.Value;
        }
        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {

            return View(_socialMedia);
        }
    }
}
