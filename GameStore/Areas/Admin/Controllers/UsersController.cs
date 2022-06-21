using System;
using GameStore.Domain;
using GameStore.Domain.Entities;
using GameStore.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;
using GameStore.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        
        UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        { 
            _userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Name, PasswordHash = model.Password };
                IdentityUserRole<string> userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = model.RoleID
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                var resultRole = await _userManager.AddToRoleAsync(user,model.Role);
                if (result.Succeeded && resultRole.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Users), nameof(HomeController).CutController());
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        { 
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Name = user.UserName, Email = user.Email };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                { 
                    user.UserName = model.Name;
                    user.Email = model.Email;
                    
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Users), nameof(HomeController).CutController());
                    }
                    else 
                    {
                        foreach (var error in result.Errors)
                        { 
                            ModelState.AddModelError(string.Empty, error.Description);  
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            { 
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(HomeController.Users), nameof(HomeController).CutController());
        }

    }
}
