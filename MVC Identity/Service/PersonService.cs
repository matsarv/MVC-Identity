using Microsoft.EntityFrameworkCore;
using MVC_Identity.Database;
using MVC_Identity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class PersonService : IPersonService
    {
        //DB Database Dependency Injection
        //readonly PeopleDbContext _peopleDBContext;
        readonly PeopleDbContext _db;

        public PersonService(PeopleDbContext peopleDBContext)
        {
            //_peopleDBContext = peopleDBContext;
            _db = peopleDBContext;
        }
        //DB

        //PersonView pv = new PersonView();

        public Person CreatePerson(Person person)
        {
            _db.Add(person);
            _db.SaveChanges();

            return person;
        }

        public List<Person> AllPersons()
        {
            //var countries = _db.Countries
            //    .Include(x => x.Cities)
            //    .ThenInclude(x => x.People)
            //    .ToList();

            //return countries;
            return _db.Persons.ToList();
        }

        public Person FindPerson(int id)
        {
            return _db.Persons.SingleOrDefault(Person => Person.Id == id);
        }

        public bool EditPerson(Person person)
        {
            bool wasUpdated = false;

            Person orginal = _db.Persons.SingleOrDefault(item => item.Id == person.Id);
            if (orginal != null)
            {
                orginal.FirstName = person.FirstName;
                orginal.LastName = person.LastName;
                orginal.Email = person.Email;

                _db.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;

        }

        public bool DeletePerson(int id)
        {
            bool wasRemoved = false;

            Person person = _db.Persons.SingleOrDefault(item => item.Id == id);
            if (person == null)
            {
                return wasRemoved;
            }

            _db.Persons.Remove(person);
            _db.SaveChanges();
            wasRemoved = true;

            return wasRemoved;

        }

    }
}
