using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace StockApp.Controllers
{
    [Route("[Controller]")]
    public class HomeController : Controller
    {
        [Route("[Action]")]
        public IActionResult Error()
        {
            ViewBag.path = "Error";
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandler != null)
            {
                ViewBag.errorMessage = exceptionHandler.Error.Message;
            }
            return View();
        }
    }
}
