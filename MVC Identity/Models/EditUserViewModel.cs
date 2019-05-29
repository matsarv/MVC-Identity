using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class EditUserViewModel
    {

        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        //public IEnumerable<IdentityRole> RolesList { get; set; }

        
        public List<IdentityUser> users = new List<IdentityUser>();
        public List<IdentityRole> roles = new List<IdentityRole>();

    }
}
