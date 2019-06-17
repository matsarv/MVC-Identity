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

                if (context.Countries.Any())
                {
                    return;   // DB has been seeded
                }
                context.Countries.AddRange(
                    new Country
                    {
                        Name = "Sweden"
                    },
                    new Country
                    {
                        Name = "Norway"
                    },
                    new Country
                    {
                        Name = "Denmark"
                    },
                    new Country
                    {
                        Name = "Finland"
                    },
                    new Country
                    {
                        Name = "Island"
                    }
                );

                context.SaveChanges();
            }

            using (var context = new PeopleDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleDbContext>>()))
            {

                if (context.Cities.Any())
                {
                    return;   // DB has been seeded
                }
                context.Cities.AddRange(
                    new City
                    {
                        Name = "Stockholm",
                        Population = "1 515 017",
                        CountryId = 1


                    },
                    new City
                    {
                        Name = "Gothenburg",
                        Population = "599 011",
                        CountryId = 1


                    },
                    new City
                    {
                        Name = "Malmoe",
                        Population = "316 588",
                        CountryId = 1


                    },
                    new City
                    {
                        Name = "Oslo",
                        Population = "1 000 467",
                        CountryId = 2

                    },
                    new City
                    {
                        Name = "Bergen",
                        Population = "255 464",
                        CountryId = 2

                    }
                    ,
                    new City
                    {
                        Name = "Stavanger",
                        Population = "222 697",
                        CountryId = 2

                    },
                    new City
                    {
                        Name = "Copenhagen",
                        Population = "1 320 629",
                        CountryId = 3

                    },
                    new City
                    {
                        Name = "Aarhus",
                        Population = "277 086",
                        CountryId = 3

                    },
                    new City
                    {
                        Name = "Odense",
                        Population = "179 601",
                        CountryId = 3

                    },
                    new City
                    {
                        Name = "Helsinki",
                        Population = "1 176 976",
                        CountryId = 4

                    },
                    new City
                    {
                        Name = "Tampere",
                        Population = "317 316",
                        CountryId = 4

                    },
                    new City
                    {
                        Name = "Turku",
                        Population = "254 671",
                        CountryId = 4

                    }

                );

                context.SaveChanges();


            }

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
                        Phone = "08-123456",
                        CityId = 1
                    },
                    new Person
                    {
                        FirstName = "Pelle",
                        LastName = "Persson",
                        Email = "pelle.persson@ab.se",
                        Phone = "08-123456",
                        CityId = 1
                    },
                    new Person
                    {
                        FirstName = "Nisse",
                        LastName = "Nilsson",
                        Email = "nisse.nilsson@ab.se",
                        Phone = "08-123456",
                        CityId = 1
                    },
                    new Person
                    {
                        FirstName = "Pelle",
                        LastName = "Persson",
                        Email = "pelle.persson@ab.se",
                        Phone = "031-123456",
                        CityId = 2
                    },
                    new Person
                    {
                        FirstName = "Nisse",
                        LastName = "Nilsson",
                        Email = "nisse.nilsson@ab.se",
                        Phone = "042-123456",
                        CityId = 3
                    },

                    new Person
                    {
                        FirstName = "Kalle",
                        LastName = "Karlsson",
                        Email = "kalle.karlsson@ab.no",
                        Phone = "08-123456",
                        CityId = 4
                    },
                    new Person
                    {
                        FirstName = "Pelle",
                        LastName = "Persson",
                        Email = "pelle.persson@ab.no",
                        Phone = "031-123456",
                        CityId = 5
                    },
                    new Person
                    {
                        FirstName = "Nisse",
                        LastName = "Nilsson",
                        Email = "nisse.nilsson@ab.no",
                        Phone = "042-123456",
                        CityId = 6
                    },

                    new Person
                    {
                        FirstName = "Kalle",
                        LastName = "Karlsson",
                        Email = "kalle.karlsson@ab.dk",
                        Phone = "08-123456",
                        CityId = 7
                    },
                    new Person
                    {
                        FirstName = "Pelle",
                        LastName = "Persson",
                        Email = "pelle.persson@ab.dk",
                        Phone = "031-123456",
                        CityId = 8
                    },
                    new Person
                    {
                        FirstName = "Nisse",
                        LastName = "Nilsson",
                        Email = "nisse.nilsson@ab.dk",
                        Phone = "042-123456",
                        CityId = 9
                    },

                    new Person
                    {
                        FirstName = "Kalle",
                        LastName = "Karlsson",
                        Email = "kalle.karlsson@ab.fi",
                        Phone = "08-123456",
                        CityId = 10
                    },
                    new Person
                    {
                        FirstName = "Pelle",
                        LastName = "Persson",
                        Email = "pelle.persson@ab.fi",
                        Phone = "031-123456",
                        CityId = 11
                    },
                    new Person
                    {
                        FirstName = "Nisse",
                        LastName = "Nilsson",
                        Email = "nisse.nilsson@ab.fi",
                        Phone = "042-123456",
                        CityId = 12
                    }



                );


                context.SaveChanges();

            }
        }
    }
}
