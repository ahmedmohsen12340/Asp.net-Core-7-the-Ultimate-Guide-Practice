using Entities;
using Services;
using ServicesContract;
using ServicesContract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitExample_UnitTest
{
    public class CountryServiceTest
    {
        private readonly ICountriesService _countriesService;
        public CountryServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry

        // when country add request is null
        [Fact]
        public void AddCountry_NullRequest()
        {
            //arrange
            CountryAddRequest? request = null;
            //assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //act
                _countriesService.AddCountry(request);
            });
        }
        //when country name is null
        [Fact]
        public void AddCountry_NullCountryName()
        {
            //arrangement
            CountryAddRequest request = new CountryAddRequest() { CountryName = null };
            //assert
            Assert.Throws<ArgumentException>(() =>
            {
                _countriesService.AddCountry(request);
            });
        }
        //when country name is duplicated
        [Fact]
        public void AddCountry_DuplicateName()
        {
            //arrangement
            CountryAddRequest request1 = new CountryAddRequest() { CountryName = "usa" };
            CountryAddRequest request2 = new CountryAddRequest() { CountryName = "usa" };
            //assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }
        //when country name is right
        [Fact]
        public void AddCountry_properCountryName()
        {
            //arrange
            CountryAddRequest request = new CountryAddRequest() { CountryName = "japan" };
            //act
            CountryResponse? countryResponse = _countriesService.AddCountry(request);
            //assert
            Assert.True(countryResponse?.CountryId != Guid.Empty);
        }

        #endregion

        #region GetCountryList

        [Fact]
        public void GetCountryList_IsEmpty()
        {
            //act
            List<CountryResponse> actualResponse = _countriesService.GetCountryList();
            //assert
            Assert.Empty(actualResponse);
        }
        [Fact]
        public void GetCountryList_addFewCountries()
        {
            //arrange
            List<CountryAddRequest> countriesRequest = new List<CountryAddRequest>()
            {
                new CountryAddRequest(){CountryName="usa"},
                new CountryAddRequest(){CountryName="uk"}
            };
            //act
            var countries_test = countriesRequest.Select(country => _countriesService.AddCountry(country)).ToList();
            List<CountryResponse?>? countries = _countriesService?.GetCountryList();
            //assert
            foreach (var test in countries_test)
                Assert.Contains(test, countries);
        }
        [Fact]
        public void GetCountryList_propercountrylist()
        {
            //arrange
            List<CountryAddRequest> countriesRequest = new List<CountryAddRequest>()
            {
                new CountryAddRequest(){CountryName="usa"},
                new CountryAddRequest(){CountryName="uk"}
            };
            //act
            var countries_test = countriesRequest.Select(country => _countriesService.AddCountry(country)).ToList();
            List<CountryResponse?>? countries = _countriesService?.GetCountryList();
            //assert
            foreach (var x in countries)
                Assert.True(x?.CountryId != Guid.Empty);
            foreach (var test in countries_test)
                Assert.Contains(test, countries);
        }

        #endregion

        #region GetCountryByCountryID

        [Fact]
        public void GetCountryByID_checkNullID()
        {
            //act
            var x = _countriesService.GetCountryByCountryID(null);
            //assert
            Assert.Null(x);
        }
        [Fact]
        public void GetCountryByID_GetMatchingCountry()
        {
            //arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "egypt" };
            CountryResponse? countryResponse= _countriesService.AddCountry(countryAddRequest);
            //act
            var actual = _countriesService.GetCountryByCountryID(countryResponse?.CountryId);
            //assert
            Assert.Equal(countryResponse, actual);
        }

        #endregion


    }
}
