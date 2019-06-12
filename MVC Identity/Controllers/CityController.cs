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
        public IActionResult Edit([Bind("Id,Name,Populatio")] int id, City city)
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
    }
}