using Asssignment10Redo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asssignment10Redo.Controllers
{
    public class BankAccountController : Controller
    {
        BankAccount b1 = new BankAccount() { AccountNumber = 1001, AccountHolderName = "Example Name", CurrentBalance = 5000 };
        [Route("/")]
        [Route("/home")]
        public IActionResult Home()
        {
            return Content("Welcome to the Best Bank", "text/plain");
        }
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            return Json(b1);
        }
        [Route("/account-statement")]
        public IActionResult AccountStatment()
        {
            return File("/MBA-Brochure.pdf", "application/pdf");
        }
        [Route("/get-current-balance/{accountNumber?}")]
        public IActionResult Balance()
        {
            if (Request.RouteValues.ContainsKey("accountNumber"))
            {
                if (int.TryParse(Convert.ToString(Request.RouteValues["accountNumber"]), out int accNum)&& accNum == 1001)
                {
                    return Content($"{b1.CurrentBalance}");
                }
                else
                    return BadRequest("Account Number should be 1001");
            }
            else
            {
                return NotFound("Account Number should be supplied");
            }

        }
    }
}
