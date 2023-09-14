using Model;
using ServicesContract;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Services
{
    public class PersonDataService : IPersonData
    {
        int Counter = 0;
        PersonData? _data;
        public PersonDataService()
        {
            _data = new PersonData($"p{Counter}") { Ssn = Guid.NewGuid() };
            Counter++;
        }
        public string? GetData()
        {   
            return  _data?.ToString();
        }

    }
}