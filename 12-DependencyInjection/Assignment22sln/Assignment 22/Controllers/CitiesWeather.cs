using Microsoft.AspNetCore.Mvc;
using ServicesContract;

namespace Assignment_22.Controllers
{
    public class CitiesWeatherController : Controller
    {
        private readonly IWeatherService? _CityWeather;
        public CitiesWeatherController(IWeatherService? cityWeather)
        {
            _CityWeather = cityWeather;
        }
        [Route("/weather")]
        [Route("/")]
        public IActionResult Home()
        {

            return View(_CityWeather?.GetWeatherDetails());
        }
        [Route("/weather/{cityCode}")]
        public IActionResult CityDetails(string? cityCode)
        {
            foreach (var city in _CityWeather?.GetWeatherDetails())
            {
                if (city.CityUniqueCode ==cityCode)
                {
                    return View(city);
                }
            }
            return Content("Invalid City Code", "text/plain");
        }
    }
}
