using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Interface;
using MVC_Identity.Models;

namespace MVC_Data.Models
{
    public class MockPersonService : IPersonService
    {
        PersonView pv = new PersonView();

        private int idCount = 1;

        public MockPersonService()
        {
            pv.persons.Add(new Person() { Id = 0, FirstName = "Nisse", LastName = "Person", Email = "nisse.person@xx.se" });
            pv.persons.Add(new Person() { Id = 1, FirstName = "Nisse", LastName = "Karlsson", Email = "nisse.karlsson@xx.se" });
            pv.persons.Add(new Person() { Id = 2, FirstName = "Kalle", LastName = "Nilsson", Email = "kalle.nilsson@xx.se" });
            pv.persons.Add(new Person() { Id = 3, FirstName = "Kalle", LastName = "Karlsson", Email = "kalle.karlsson@xx.se" });
            pv.persons.Add(new Person() { Id = 4, FirstName = "Pelle", LastName = "Nilsson", Email = "pelle.nilsson@xx.se" });
            pv.persons.Add(new Person() { Id = 5, FirstName = "Pelle", LastName = "Person", Email = "pelle.Person@xx.se" });
        }

        public Person CreatePerson(Person person)
        {
            pv.persons.Add(new Person() { Id = idCount, FirstName = "Nisse", LastName = "Person", Email = "nisse.person@xx.se" });
            idCount++;

            pv.persons.Add(person);

            return person;
        }

        public List<Person> AllPersons()
        {
            return pv.persons;
        }

        public Person FindPerson(int id)
        {
            foreach (Person item in pv.persons)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public bool EditPerson(Person person)
        {
            bool wasUpdated = false;

            foreach (Person orginal in pv.persons)
            {
                if (orginal.Id == person.Id)
                {
                    orginal.FirstName = person.FirstName;
                    orginal.LastName = person.LastName;
                    orginal.Email = person.Email;

                    wasUpdated = true;
                    break;
                }
            }

            return wasUpdated;
        }

        public bool DeletePerson(int id)
        {
            bool wasRemoved = false;

            foreach (Person item in pv.persons)
            {
                if (item.Id == id)
                {
                    pv.persons.Remove(item);

                    wasRemoved = true;
                    break;
                }
            }

            return wasRemoved;
        }
    }
}
