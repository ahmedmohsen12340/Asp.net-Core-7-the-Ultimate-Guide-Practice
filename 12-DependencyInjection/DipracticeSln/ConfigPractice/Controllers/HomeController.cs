using Microsoft.AspNetCore.Mvc;
using ServicesContract;

namespace ConfigPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonData _personData1;
        private readonly IPersonData _personData2;
        private readonly IPersonData _personData3;
        private readonly IServiceScopeFactory _scope;
        public HomeController(IPersonData personData1, IPersonData personData2, IPersonData personData3,IServiceScopeFactory scope)
        {
            _personData1 = personData1;
            _personData2 = personData2;
            _personData3 = personData3;
            _scope = scope;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.p1 = _personData1.GetData();
            ViewBag.p2 = _personData2.GetData();
            ViewBag.p3 = _personData3.GetData();
            using (IServiceScope scope = _scope.CreateScope())
            {
                ViewBag.Pchild = scope.ServiceProvider.GetRequiredService<IPersonData>().GetData();
            }
                return View();
        }
    }
}
