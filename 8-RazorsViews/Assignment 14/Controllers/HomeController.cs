using Assignment_14.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace Assignment_14.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> list = new List<CityWeather>()
        {
            new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = new DateTime(2030,1,1,8,0,0), TemperatureFahrenheit = 33 },
            new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030,1,1,3,0,0),  TemperatureFahrenheit = 60},
            new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030,1,1,9,0,0),  TemperatureFahrenheit = 82 }
        };
        [Route("/")]
        public IActionResult Index()
        {
            //"2030-01-01 8:00"
            return View(list);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult cityDetails(string? cityCode)
        {
            foreach(var city in list)
            {
                if(city.CityUniqueCode == cityCode)
                    return View(city);
            }
            return Content("The City Code is invalid");
        }
    }
}
