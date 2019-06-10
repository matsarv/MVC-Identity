using MVC_Identity.Database;
using MVC_Identity.Interface;
using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Service
{

    public class CityService : ICityService
    {

        readonly PeopleDbContext _db;

        public CityService(PeopleDbContext peopleDBContext)
        {
            //_peopleDBContext = peopleDBContext;
            _db = peopleDBContext;
        }



        public List<City> AllCities()
        {
            return _db.Cities.ToList();
        }


    }
}
