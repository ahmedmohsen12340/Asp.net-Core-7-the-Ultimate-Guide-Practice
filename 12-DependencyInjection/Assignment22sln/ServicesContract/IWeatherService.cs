using System.Collections.Generic;

namespace ServicesContract
{
    public interface IWeatherService
    {
        List<Cityweather> GetWeatherDetails(); //- Returns a list of CityWeather objects that contains weather details of cities
        Cityweather? GetWeatherByCityCode(string CityCode); //- Returns an object of CityWeather based on the given city code
    }
}