using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Database
{
    //public class PeopleDbContext : DbContext
    public class PeopleDbContext : IdentityDbContext<IdentityUser>
    {

        // Rebuild Project
        // Add-Migration init_people
        // Rebuild Project
        // Update-Database

        //DB
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        //DB
    }

}
