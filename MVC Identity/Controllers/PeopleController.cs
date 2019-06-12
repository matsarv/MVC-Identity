using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Interface;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    [Authorize(Roles = "Admin,NormalUser")]
    public class PeopleController : Controller
    {
        IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: People
        [HttpGet]
        public IActionResult Index()
        {
            PersonView pv = new PersonView
            {
                persons = _personService.AllPersons()
            };

            return View(pv);
        }

        // GET: People/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        //GET: People/Create
        public IActionResult Create(int? id)
        {
            ViewBag.CityId = id;
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Email,Phone,CityId")] Person person)
        {
            if (ModelState.IsValid)
            {
                 _personService.CreatePerson(person);

                return RedirectToAction(nameof(Index),"Country");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,FirstName,LastName,Email,Phone")] int id, Person person)
        {
            if (ModelState.IsValid)
            {
                bool succeeded = _personService.EditPerson(person);

                if (succeeded)
                {
                    return RedirectToAction(nameof(Details), "People", new { id });
                }

                return NotFound();
            }

            return View(person);
        }

        // GET: People/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person person = _personService.FindPerson((int)id);

            if (person == null)
            {
                return NotFound();
            }

            _personService.DeletePerson((int)id);

            return RedirectToAction(nameof(Index), "Country");
        }

    }
}