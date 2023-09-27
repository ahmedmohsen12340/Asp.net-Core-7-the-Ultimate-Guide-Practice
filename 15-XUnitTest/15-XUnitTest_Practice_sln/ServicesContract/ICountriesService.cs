using ServicesContract.DTOs;

namespace ServicesContract
{
    /// <summary>
    /// Representing business logic for manipulating country country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// to add country object to countries list
        /// </summary>
        /// <param name="request">country object to add</param>
        /// <returns>returning country object after adding it to country list in form of country response</returns>
        CountryResponse? AddCountry(CountryAddRequest? request);
        /// <summary>
        /// returns country list of all countries added
        /// </summary>
        /// <returns>it return it in country response object</returns>
        List<CountryResponse?> GetCountryList();
        /// <summary>
        /// to search if country exist in the list or not
        /// </summary>
        /// <param name="countryID">the country id for country we are looking for</param>
        /// <returns>country response or null if it not exist</returns>
        public CountryResponse? GetCountryByCountryID(Guid? countryID);
    }
}