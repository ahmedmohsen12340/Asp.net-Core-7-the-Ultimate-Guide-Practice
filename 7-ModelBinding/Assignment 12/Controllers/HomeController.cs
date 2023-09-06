using Assignment_12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_12.Controllers
{
    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                var Errors = ModelState.Values.SelectMany(value=> value.Errors)
                    .Select(error=>error.ErrorMessage).ToList();
                string errorMessage= string.Join("\n", Errors);
                return BadRequest(errorMessage);
            }
            Random x = new Random();
            order.OrderNo = x.Next(1, 99999);
            return Json(order);
        }
    }
}
