using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public IActionResult Create()
        {
            return View();
        }

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
    }
}