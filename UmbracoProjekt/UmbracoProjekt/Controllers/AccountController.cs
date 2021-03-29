using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmbracoProjekt.Models;

namespace UmbracoProjekt.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (!ModelState.IsValid)
                return View(registration);

            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };
            var result = await userManager.CreateAsync(newUser, registration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return View();
            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await signInManager.PasswordSignInAsync(login.EmailAddress, login.Password, login.RememberMe, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Form");
            }
            return Redirect(returnUrl);
        }
        [HttpPost]
        [Route("Account/Logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await signInManager.SignOutAsync();
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Form");
            }
            return Redirect(returnUrl);
        }
    }
}
