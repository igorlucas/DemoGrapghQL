using Domain.Entities;
using System.Collections.Generic;

namespace Web.Contracts.IRepositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> Countries { get; }
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        bool CountryExists(string id);
        bool CountryWasUpdated(Country country);    
        bool Commit();
    }
}
