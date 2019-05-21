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
            return _db.Persons.ToList();
        }

        public Person FindPerson(int id)
        {
            return _db.Persons.SingleOrDefault(Person => Person.Id == id);

            //foreach (Person item in pv.persons)
            //{
            //    if (item.Id == id)
            //    {
            //        return item;
            //    }
            //}

            //return null;
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

            //foreach (Person orginal in pv.persons)
            //{
            //    if (orginal.Id == person.Id)
            //    {
            //        orginal.FirstName = person.FirstName;
            //        orginal.LastName = person.LastName;
            //        orginal.Email = person.Email;

            //        wasUpdated = true;
            //        break;
            //    }
            //}

            //return wasUpdated;
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

            //foreach (Person item in pv.persons)
            //{
            //    if (item.Id == id)
            //    {
            //        pv.persons.Remove(item);

            //        wasRemoved = true;
            //        break;
            //    }
            //}

            //return wasRemoved;
        }

    }
}
