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

        private int idCount = 3;

        public MockPersonService()
        {
            pv.persons.Add(new Person() { Id = 0, FirstName = "11Nisse", LastName = "Karlsson", Email = "kalle.karlsson@ab.se", Phone = "08-123456" });
            pv.persons.Add(new Person() { Id = 1, FirstName = "Pelle", LastName = "Persson", Email = "pelle.persson@ab.se", Phone = "031-123456" });
            pv.persons.Add(new Person() { Id = 2, FirstName = "Nisse", LastName = "Nilsson", Email = "nisse.nilsson@ab.se", Phone = "042-123456" });
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
