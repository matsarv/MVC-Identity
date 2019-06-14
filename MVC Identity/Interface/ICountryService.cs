using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Interface
{
    public interface ICountryService
    {
        //Create
        Country CreateCountry(Country country);

        //Read
        Country FindCountry(int id);
        List<Country> AllCountries();

        //Update
        //bool EditCountry(Country country);

        //Delete
        bool DeleteCountry(int id);
    }
}
