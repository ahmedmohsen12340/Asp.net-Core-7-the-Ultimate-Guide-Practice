using Microsoft.AspNetCore.Mvc;
using RazorsViewsTraining.Models;

namespace RazorsViewsTraining.Controllers
{
    [Route("/")]
    [Route("/Home")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Person person = new Person() { Id=5,Name="Mohsen",Job="Engineer"};
            //ViewData["person"]=person;
            ViewBag.person = person;
            return View(person);
        }
    }
}
