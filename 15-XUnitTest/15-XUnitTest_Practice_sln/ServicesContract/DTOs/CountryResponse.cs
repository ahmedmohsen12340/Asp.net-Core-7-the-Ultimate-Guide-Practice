using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract.DTOs
{
    /// <summary>
    /// DTO to send country response
    /// </summary>
    public class CountryResponse
    {
        public Guid? CountryId { get; set; }
        public string? CountryName { get; set; }
        public override bool Equals(object? obj)
        {
            if((obj is CountryResponse x)&&(CountryId == x.CountryId)&&(CountryName == x.CountryName))
            {
                return true;                
            }
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    public static class CountryExtentions 
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { CountryId = country.CountryID, CountryName = country.CountryName };
        }
    }
}
