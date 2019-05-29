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
            PersonView pv = new PersonView();

            pv.persons = _personService.AllPersons();

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
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Email")] Person person)
        {

            if (ModelState.IsValid)
            {
                 _personService.CreatePerson(person);

                return RedirectToAction(nameof(Index));
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
        public IActionResult Edit([Bind("Id,FirstName,LastName,Email")] int id, Person person)
        {

            if (ModelState.IsValid)
            {
                bool succeeded = _personService.EditPerson(person);

                if (succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }

            return View(person);

        }

        // GET: People/Delete/5
        [Authorize(Roles = "NormalUser")]
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

            return RedirectToAction(nameof(Index));

        }

    }
}