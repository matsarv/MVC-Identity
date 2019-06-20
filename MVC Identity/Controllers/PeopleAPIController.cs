using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Interface;
using MVC_Identity.Models;

//Create – POST
//Read – GET
//Update – PUT
//Delete – DELETE

namespace MVC_Identity.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleAPIController : ControllerBase
    {

        IPersonService _personService;

        public PeopleAPIController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/PeopleAPI
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personService.AllPersons();
        }

        // GET: api/PeopleAPI/5
        [HttpGet("{id}", Name = "Get")]
        public Person Get(int? id)
        {
            if (id == null)
            {
                return null;
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return null;
            }

            return person;
        }

        // POST: api/PeopleAPI
        [HttpPost]
        public Person Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.CreatePerson(person);

                return person;
            }

            return null;
        }

        // PUT: api/PeopleAPI/5
        [HttpPut("{id}")]
        public Person Put(int id, [FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                bool succeeded = _personService.EditPerson(person);

                if (succeeded)
                {
                    return person;
                }

                return null;
            }

            return person;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return false;
            }

             _personService.DeletePerson((int)id);

            return true;
        }
    }
}
