using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_Data.Models;
using MVC_Identity.Database;
using MVC_Identity.Interface;
using MVC_Identity.Models;
using MVC_Identity.Service;

namespace MVC_Identity
{
    public class Startup
    {
        //DB Database Constructor Injection
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration config) { Configuration = config; }
        //DB

        //API
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // Dependency Injection
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            // Service for using a Mock
            //services.AddSingleton<IPersonService, MockPersonService>();

            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-2.2&tabs=visual-studio
            //DB Database Context
            services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Able to inject our User/Role/SignIn Manager´s
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<PeopleDbContext>();

            services.Configure<IdentityOptions>(options =>
            {   // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // User settings.
                //options.User.RequireUniqueEmail = true;
                // Lockout settings.
                //options.Lockout.AllowedForNewUsers = true;
                //options.Lockout.MaxFailedAccessAttempts = 3;
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            });

            //services.ConfigureApplicationCookie(option => { option.LoginPath = "/Logins/Index"; });

            services.Configure<PasswordHasherOptions>(option =>
            {// default 10_000 is getting old so we incress it to be more on the safe side
                option.IterationCount = 100_000;
            });

            // claims roles // Use in Controller
            //services.AddAuthorization(option =>
            //{
            //    option.AddPolicy("DeletePerson", policy =>
            //    {
            //        //policy.RequireClaim("Over18Claim");
            //        policy.RequireRole("NormalUser");
            //        //policy.RequireRole("Editor");


            //    });
            //});

            //API https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-2.2
            //services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //API
            app.UseCors(MyAllowSpecificOrigins);

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
