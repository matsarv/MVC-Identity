using Microsoft.EntityFrameworkCore;
using MVC_Identity.Database;
using MVC_Identity.Interface;
using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Service
{
    public class CountryService : ICountryService
    {
        readonly PeopleDbContext _db;

        public CountryService(PeopleDbContext peopleDBContext)
        {
            _db = peopleDBContext;
        }

        public Country CreateCountry(Country country)
        {
            _db.Add(country);
            _db.SaveChanges();

            return country;
        }

        public List<Country> AllCountries()
        {
            var countries = _db.Countries
                .Include(x => x.Cities)
                .ThenInclude(x => x.People)
                .ToList();

            return countries;
        }

        public Country FindCountry(int id)
        {
            return _db.Countries.SingleOrDefault(Country => Country.Id == id);
        }

        public bool DeleteCountry(int id)
        {
            bool wasRemoved = false;

            Country country = _db.Countries.SingleOrDefault(item => item.Id == id);
            if (country == null)
            {
                return wasRemoved;
            }

            City city= _db.Cities.SingleOrDefault(item => item.CountryId == id);
            if (city != null)
            {
                return wasRemoved;
            }

            _db.Countries.Remove(country);
            _db.SaveChanges();
            wasRemoved = true;

            return wasRemoved;

        }

    }
}
