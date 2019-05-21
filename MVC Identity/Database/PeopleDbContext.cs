using Microsoft.EntityFrameworkCore;
using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Database
{
    public class PeopleDbContext : DbContext
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
