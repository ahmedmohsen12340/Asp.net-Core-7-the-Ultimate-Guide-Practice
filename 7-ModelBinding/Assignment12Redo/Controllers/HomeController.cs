using Assignment12Redo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment12Redo.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join('\n', ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage));
                return BadRequest(errors);
            }
            else
                return Json(order);
        }
    }
}
