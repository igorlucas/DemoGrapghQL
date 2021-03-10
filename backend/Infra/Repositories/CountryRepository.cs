using Domain.Entities;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web.Contracts.IRepositories;

namespace Infra.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _db;
        public CountryRepository(DataContext db) => _db = db;

        public IEnumerable<Country> Countries => _db.Countries.ToArray();
        public void CreateCountry(Country country) => _db.Countries.Add(country);
        public void UpdateCountry(Country country) => _db.Entry(country).State = EntityState.Modified;
        public bool CountryExists(string id) => _db.Countries.Any(c => c.Id == id);
        public bool CountryWasUpdated(Country country) => _db.Countries.Any(c => c.Equals(country));
        public bool Commit() => (_db.SaveChanges() > 0);
    }
}
