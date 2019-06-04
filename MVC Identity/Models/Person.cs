using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
