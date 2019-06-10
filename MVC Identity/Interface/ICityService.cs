using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Interface
{
    public interface ICityService
    {

        List<City> AllCities();
    }
}
