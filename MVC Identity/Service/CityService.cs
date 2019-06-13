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


        public City CreateCity(City city)
        {
            _db.Add(city);
            _db.SaveChanges();

            return city;
        }

        public List<City> AllCities()
        {
            return _db.Cities.ToList();
        }

        public City FindCity(int id)
        {
            return _db.Cities.SingleOrDefault(City => City.Id == id);
        }

        public bool EditCity(City city)
        {
            bool wasUpdated = false;

            City orginal = _db.Cities.SingleOrDefault(item => item.Id == city.Id);
            if (orginal != null)
            {
                orginal.Name = city.Name;
                orginal.Population = city.Population;

                _db.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;

        }

        public bool DeleteCity(int id)
        {
            bool wasRemoved = false;

            City city = _db.Cities.SingleOrDefault(item => item.Id == id);
            if (city == null)
            {
                return wasRemoved;
            }

            Person person = _db.Persons.SingleOrDefault(item => item.CityId == id);
            if (person != null)
            {
                return wasRemoved;
            }

            _db.Cities.Remove(city);
            _db.SaveChanges();
            wasRemoved = true;

            return wasRemoved;

        }
    }
}
