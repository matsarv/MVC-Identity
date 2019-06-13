using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Interface;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class CityController : Controller
    {
        ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City city = _cityService.FindCity((int)id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        public IActionResult Create(int? id)
        {
            ViewBag.CountryId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Population,CountryId")] City city)
        {
            if (ModelState.IsValid)
            {
                _cityService.CreateCity(city);

                return RedirectToAction(nameof(Index), "Country");
            }

            return View(city);
        }
    
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City city = _cityService.FindCity((int)id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Population")] int id, City city)
        {
            if (ModelState.IsValid)
            {
                bool succeeded = _cityService.EditCity(city);

                if (succeeded)
                {
                    return RedirectToAction(nameof(Details), "City", new { id });
                }

                return NotFound();
            }

            return View(city);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City city = _cityService.FindCity((int)id);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City city = _cityService.FindCity((int)id);

            if (city == null)
            {
                return NotFound();
            }

            _cityService.DeleteCity((int)id);

            return RedirectToAction(nameof(Index), "Country");
        }

    }

}
