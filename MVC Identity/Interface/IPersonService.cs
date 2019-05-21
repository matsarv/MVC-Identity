
using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Interface
{
    public interface IPersonService
    {
        //Create
        Person CreatePerson(Person person);

        //Read
        Person FindPerson(int id);
        List<Person> AllPersons();

        //Update
        bool EditPerson(Person person);

        //Delete
        bool DeletePerson(int id);
    }
}
