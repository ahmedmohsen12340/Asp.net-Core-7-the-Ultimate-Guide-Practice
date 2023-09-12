using Assignment16Redo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment16Redo.Controllers
{
    public class CitiesWeatherController : Controller
    {
        List<Cityweather> cities = new List<Cityweather>()
            {
                new Cityweather(){CityUniqueCode = "LDN", CityName = "London",DateAndTime = new DateTime(2030,1,1,8,0,0), TemperatureFahrenheit = 33 },
                new Cityweather(){CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030,1,1,3,0,0),TemperatureFahrenheit = 60},
                new Cityweather(){CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030,1,1,9,0,0),  TemperatureFahrenheit = 82}
            };
        [Route("/weather")]
        [Route("/")]
        public IActionResult Home()
        {

            return View(cities);
        }
        [Route("/weather/{cityCode}")]
        public IActionResult CityDetails(string? cityCode)
        {
            foreach(var city in cities)
                if(cityCode == city.CityUniqueCode)
                    return View(city);
            return Content("Invalid City Code", "text/plain");
        }
    }
}
