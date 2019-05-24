using Microsoft.AspNetCore.Identity;
using MVC_Identity.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity
{
    internal class DbInitializer
    {

        internal static void Initialize(PeopleDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole("Admin");
                // Add custom properties
                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole("User");
                // Add custom properties
                roleManager.CreateAsync(role).Wait();
            }

            //---------------------------------------------------->

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Email = "admin@ab.se";
                user.UserName = "Admin";

                IdentityResult result = userManager.CreateAsync(user, "!Sommar2019").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }

            }

            if (userManager.FindByNameAsync("NormalUser").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.Email = "mats@ab.se";
                user.UserName = "Mats";

                IdentityResult result = userManager.CreateAsync(user, "!Sommar2019").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }

            }

            //---------------------------------------------------->

            // Userdata
            //context.SaveChanges();


        }
    }
}
