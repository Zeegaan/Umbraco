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
            //dependency injection
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
            //Checking modelstate
            if (!ModelState.IsValid)
                return View(registration);
            //Making new user with EmailAdress
            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };
            //Try creating User
            var result = await userManager.CreateAsync(newUser, registration.Password);
            //Check if we was succesful, if not, return error
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
            //Checking modelstate
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Try to sign in
            var result = await signInManager.PasswordSignInAsync(login.EmailAddress, login.Password, login.RememberMe, false);
            //Check if succesful, if not, return error
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }
            //Check if we have a return url, if not, return to Form/Index
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
            //Signout
            await signInManager.SignOutAsync();
            //Check if we have a return url, if not, return to Form/Index
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Form");
            }
            return Redirect(returnUrl);
        }
    }
}
