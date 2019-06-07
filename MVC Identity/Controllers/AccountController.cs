using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(RoleManager<IdentityRole> roleManager,
                                 UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)// Constructor Injection´s
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserVM createUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = createUser.UserName, Email = createUser.Email };
                var CreateResult = await _userManager.CreateAsync(user, createUser.Password);

                if (CreateResult.Succeeded)
                {
                    var role = "NormalUser";
                    var result = await _userManager.AddToRoleAsync(user, role);

                    ViewBag.msg = "User was created.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.errorlist = CreateResult.Errors;
                }
            }

            return View(createUser);

        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var LoginResult = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

                switch (LoginResult.ToString())
                {
                    case "Succeeded":
                        return RedirectToAction("Index", "People");

                    case "Failed":
                        ViewBag.msg = "Failed - Username of/and Password is incorrect";
                        break;
                    case "Lockedout":
                        ViewBag.msg = "Locked Out";
                        break;
                    default:
                        ViewBag.msg = LoginResult.ToString();
                        break;
                }
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ManageUsers()
        {
            return View(_userManager.Users.ToList());
        }

    }
}