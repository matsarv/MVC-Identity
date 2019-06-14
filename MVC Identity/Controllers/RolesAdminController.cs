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
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RolesAdminController(RoleManager<IdentityRole> roleManager,
                                 UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)// Constructor Injection´s
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return View();
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(name));

            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }

            return View(name);
        }

        [HttpGet]
        public IActionResult AddUserToRole(string role)
        {
            ViewBag.Role = role;

            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToRoleSave(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var newRole = await _roleManager.FindByNameAsync(role);
            var result = await _userManager.AddToRoleAsync(user, role);

            return RedirectToAction(nameof(Details), "RolesAdmin" , new { id = newRole.Id });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserFromRoleSave(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var newRole = await _roleManager.FindByNameAsync(role);
            var result = await _userManager.RemoveFromRoleAsync(user, role);

            return RedirectToAction(nameof(Details), "RolesAdmin", new { id = newRole.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            //IdentityUser user = _userManager.FindByIdAsync(id);
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            await _roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var roleusers = new RoleUsersViewModel();
            roleusers.Role = await _roleManager.FindByIdAsync(id);
            roleusers.Users = await _userManager.GetUsersInRoleAsync(roleusers.Role.Name);

            if (roleusers == null)
            {
                return NotFound();
            }

            return View(roleusers);
        }
    }
}