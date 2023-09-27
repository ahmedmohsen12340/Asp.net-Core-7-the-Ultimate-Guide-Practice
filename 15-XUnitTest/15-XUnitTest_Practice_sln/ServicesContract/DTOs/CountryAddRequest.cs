using Entities;
using System;
using System.Collections.Generic;

namespace ServicesContract.DTOs
{
    /// <summary>
    /// DTO for creating new countries
    /// </summary>
    public class CountryAddRequest
    {
        public string? CountryName { get; set; }
        public Country ToCountry()
        {
            return new Country { CountryName = CountryName };
        }
    }
}
