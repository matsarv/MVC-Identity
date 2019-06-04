using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Identity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVC_Identity.Models
{
    //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-2.2&tabs=visual-studio

    public static class SeedData
 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleDbContext>>()))
            {

                if (context.Persons.Any())
                {
                    return;   // DB has been seeded
                }
                context.Persons.AddRange(
                    new Person
                    {
                        FirstName = "Kalle",
                        LastName = "Karlsson",
                        Email = "kalle.karlsson@ab.se",
                        Phone = "08-123456"
                    },
                    new Person
                    {
                        FirstName = "Pelle",
                        LastName = "Persson",
                        Email = "pelle.persson@ab.se",
                        Phone = "031-123456"
                    },
                    new Person
                    {
                        FirstName = "Nisse",
                        LastName = "Nilsson",
                        Email = "nisse.nilsson@ab.se",
                        Phone = "042-123456"
                    }

                );
                context.SaveChanges();

            }
        }
    }
}
