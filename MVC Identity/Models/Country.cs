using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }



    //public CountryName? CountryName { get; set; }

    public enum CountryName
    {
        Select,
        Arabia,
        Argentina,
        Australia,
        Brasil,
        Canada,
        Catalonia,
        Chile,
        China,
        Colombia,
        Denmark,
        Egypt,
        Extremadura,
        Finland,
        France,
        Germany,
        Greece,
        Guatemala,
        Ireland,
        Island,
        Italia,
        Japan,
        Libya,
        Mexico,
        Netherlands,
        NewZealand,
        Norway,
        Poland,
        Russia,
        Spain,
        //[Display(Name = "Sweden")]
        Sweden,
        UK,
        [Display(Name = "USA")]
        USA,
        Venezuela,
        Zambia,
    }

}
