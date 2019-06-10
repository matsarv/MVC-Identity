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

                if (context.Persons.Any())
                {
                    return;   // DB has been seeded
                }
                context.Countries.AddRange(
                    new Country
                    {
                        Name = "Finland"

                    },
                    new Country
                    {
                        Name = "Denmark"

                    },
                    new Country
                    {
                        Name = "Norway"

                    },
                    new Country
                    {
                        Name = "Sweden"

                    }

                );

                if (context.Cities.Any())
                {
                    return;   // DB has been seeded
                }
                context.Cities.AddRange(
                    new City
                    {
                        Name = "Stockholm",
                        Population= "1 515 017"

                        

                    },
                    new City
                    {
                        Name = "Gothenburg",
                        Population = "599 011"

                    },
                    new City
                    {
                        Name = "Malmoe",
                        Population = "316 588"

                    },
                    new City
                    {
                        Name = "Oslo",
                        Population = "1 000 467"

                    },
                    new City
                    {
                        Name = "Bergen",
                        Population = "255 464"

                    }
                    ,
                    new City
                    {
                        Name = "Stavanger",
                        Population = "222 697"

                    },
                    new City
                    {
                        Name = "Copenhagen",
                        Population = "1 320 629"

                    },
                    new City
                    {
                        Name = "Aarhus",
                        Population = "277 086"

                    },
                    new City
                    {
                        Name = "Odense",
                        Population = "179 601"

                    },
                    new City
                    {
                        Name = "Helsinki",
                        Population = "1 176 976"

                    },
                    new City
                    {
                        Name = "Tampere",
                        Population = "317 316"

                    },
                    new City
                    {
                        Name = "Turku",
                        Population = "254 671"

                    }

                );

                context.SaveChanges();

            }
        }
    }
}
