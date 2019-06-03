using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserAdminController(RoleManager<IdentityRole> roleManager,
                                 UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)// Constructor Injection´s
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }


                       public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVM createUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser() { UserName = createUser.UserName, Email = createUser.Email };
                var result = await _userManager.CreateAsync(user, createUser.Password);

                if (result.Succeeded)
                {
                    ViewBag.msg = "User was created.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.errorlist = result.Errors;
                }
            }

            return View(createUser);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            //IdentityUser user = _userManager.FindByIdAsync(id);
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            //IdentityUser user = _userManager.FindByIdAsync(id);
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            //IdentityUser user = _userManager.FindByIdAsync(id);
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirm([Bind("Id,UserName,Email")] string id, IdentityUser identityUser)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            //IdentityUser user = _userManager.FindByIdAsync(id);
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = identityUser.UserName;
            user.Email = identityUser.Email;


            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                ViewBag.msg = "User was updated.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.errorlist = result.Errors;
            }

            return View(user);


        }
    }
}