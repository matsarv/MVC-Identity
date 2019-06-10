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
        ICityService _cityService;

        public CountryController(ICountryService countryService, ICityService cityService)
        {
            _countryService = countryService;
            _cityService = cityService;

        }


        public IActionResult Index()
        {
            var countries = _countryService.AllCountries();
            //var cities = _cityService.AllCities();

            //CountryCitiesViewModel vm = new CountryCitiesViewModel();

            //vm.country = countries;
            //vm.cities = cities;

            return View(countries);
        }
    }
}