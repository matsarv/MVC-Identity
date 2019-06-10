using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class CountryCitiesViewModel
    {
        public Country country { get; set; }
        public IList<City> cities { get; set; }
    }
}
