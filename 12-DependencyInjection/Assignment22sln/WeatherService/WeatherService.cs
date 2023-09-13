using ServicesContract;

namespace Services
{
    public class WeatherService : IWeatherService
    {
        List<Cityweather> cities = new List<Cityweather>()
            {
                new Cityweather(){CityUniqueCode = "LDN", CityName = "London",DateAndTime = new DateTime(2030,1,1,8,0,0), TemperatureFahrenheit = 33 },
                new Cityweather(){CityUniqueCode = "NYC", CityName = "New York", DateAndTime = new DateTime(2030,1,1,3,0,0),TemperatureFahrenheit = 60},
                new Cityweather(){CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = new DateTime(2030,1,1,9,0,0),  TemperatureFahrenheit = 82}
            };

        public Cityweather? GetWeatherByCityCode(string CityCode)
        {
            foreach (var city in cities)
            {
                if (city.CityUniqueCode == CityCode)
                    return city;
            }
            return null;
        }

        public List<Cityweather> GetWeatherDetails()
        {
            return cities;
        }

    }
}