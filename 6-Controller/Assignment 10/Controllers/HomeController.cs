using Assignment_10.modules;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_10.Controllers
{
    public class HomeController : Controller
    {
        BankAccount bankAccount = new BankAccount() 
            { AccountNumber=1001,AccountHolderName= "Example Name",currentBalance=5000 };
        [Route("/")]
        public IActionResult home()
        {
            return Content("Welcome to the Best Bank", "text/plain");
        }
        [Route("/account-details")]
        public IActionResult Details()
        {
            return Json(bankAccount);
        }
        [Route("/account-statement")]
        public IActionResult statment()
        {
            return File("/MBA-Brochure.pdf", "application/pdf");
        }
        [Route("/get-current-balance/{accountNumber:int}")]
        public IActionResult balance()
        {
            var accNum = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            if (accNum == 1001)
            {
                return Content($"{bankAccount.currentBalance}");
            }
            else
            {
                return BadRequest("Account Number should be 1001");
            }
        }
        [Route("/get-current-balance/")]
        public IActionResult errorBalance()
        {
            return NotFound("Account Number should be supplied");
        }


    }
}
