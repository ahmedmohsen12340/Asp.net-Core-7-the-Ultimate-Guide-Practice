using Entities;
using ServicesContract;
using ServicesContract.DTOs;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country>? _countries;
        public CountriesService()
        {
            _countries = new List<Country>();
        }
        public CountryResponse? AddCountry(CountryAddRequest? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if(request.CountryName==null) throw new ArgumentException(nameof(request.CountryName));
            Country country =request.ToCountry();
            if (_countries.Where(country=> country.CountryName==request.CountryName).Count()>0)
                throw new ArgumentException("the Country name is Repeated");
            country.CountryID = Guid.NewGuid();
            _countries.Add(country);
            return country.ToCountryResponse();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if(countryID==null)
                return null;
            var country = _countries?.Where(country=> country.CountryID==countryID).FirstOrDefault();
            return country!=null? country.ToCountryResponse():null;
        }

        public List<CountryResponse?> GetCountryList()
        {
            var countries = _countries?.Select(country => country.ToCountryResponse()).ToList();
            return countries;
        }
    }
}