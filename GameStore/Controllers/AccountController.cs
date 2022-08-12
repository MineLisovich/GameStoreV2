using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Models;
using GameStore.Domain.Repositories.EntityFramework;
using GameStore.Domain.Repositories;
using GameStore.Service;

namespace GameStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }


        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new RegistrationViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.UserName, PasswordHash = model.PasswordHash };
                IdentityUserRole<string> userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = "602"
                };

                // добавляем пользователя
                var result = await userManager.CreateAsync(user, model.PasswordHash);
                var resultRole = await userManager.AddToRoleAsync(user, "USER");
                if (result.Succeeded)
                {
                    // генерация токена для пользователя 
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new {User = user.Id, code = code},
                        protocol: HttpContext.Request.Scheme);
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(model.Email, "Confirm your account", $"Подтвердите регистрацию, перейдя по ссылке: <a href = '{callbackUrl}'>link</a>");
                    return RedirectToAction("ConfirmEmail", "Home");
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
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string User, string code)
        {
            if (User == null || code == null)
            {
                return Content("Ошибка подтверждения почты, напишите письмо с проблемой на почту deelimpay@mail.ru");
            }
            var userid = await userManager.FindByIdAsync(User);
            if (userid == null) 
            {
                return Content("Ошибка подтверждения почты, напишите письмо с проблемой на почту deelimpay@mail.ru");
            } 
                
            var result = await userManager.ConfirmEmailAsync(userid, code);
            if (result.Succeeded)
            {
                // установка куки
                await signInManager.SignInAsync(userid, false);
                return RedirectToAction("Index", "Home");
            }
            else {
                return Content("Ошибка подтверждения почты, напишите письмо с проблемой на почту deelimpay@mail.ru");
            }
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string resultUrl)
        {
            if (ModelState.IsValid)
            {
               
                IdentityUser user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (!await userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                        return RedirectToAction("ConfirmEmail", "Home");
                    }
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {

                        return Redirect(resultUrl ?? "/Home/index");

                    }
                    ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный Логин или Пароль");
                }
            }
            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


      

       

    }
}
