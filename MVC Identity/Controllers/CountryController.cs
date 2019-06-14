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
    
    public class CountryController : Controller
    {

        ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            List<Country> countries = _countryService.AllCountries();

            return View(countries);

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country country  = _countryService.FindCountry((int)id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.CreateCountry(country);

                return RedirectToAction(nameof(Index), "Country");
            }

            return View(country);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country country = _countryService.FindCountry((int)id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
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

             Country country = _countryService.FindCountry((int)id);

            if (country == null)
            {
                return NotFound();
            }

            _countryService.DeleteCountry((int)id);

            return RedirectToAction(nameof(Index), "Country");
        }

        public IActionResult Test()
        {
            List<Country> countries = _countryService.AllCountries();

            return View(countries);

        }
    }
}