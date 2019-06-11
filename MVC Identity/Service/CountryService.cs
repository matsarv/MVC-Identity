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
            //_peopleDBContext = peopleDBContext;
            _db = peopleDBContext;
        }

        public List<Country> AllCountries()
        {
            var countries = _db.Countries
                .Include(x => x.Cities)
                .ThenInclude(x => x.People)
                .ToList();

            return countries;
        }

    }
}
