using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EnglishCourse.Logic.Interfaces;
using EnglishCourse.Model.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishCourse.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) //если не все поля формы введены
            {
                return View(model);
            }

            var logmodel = _accountService.Login(model);

            if (logmodel.Message != null)
            {
                return View(logmodel);
            }

            await Authenticate(model.Email);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var regmodel = _accountService.Registration(model);

            if (regmodel.Message != null)
            {
                return View(regmodel);
            }

            await Authenticate(model.Email);

            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _accountService.GetRole(userName))
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [Authorize(Roles = "User")]
        public IActionResult MyProfile()
        {
            AccountVM account = _accountService.GetByName(User.Identity.Name);

            return View(account);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult MyProfile(AccountVM model)
        {
            _accountService.Update(model);

            Thread.Sleep(1000);

            return View(model);
        }

        [Authorize(Roles = "User")]
        public IActionResult About()
        {
            AccountVM account = _accountService.GetByName(User.Identity.Name);

            return View(account);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult About(AccountVM model)
        {
            _accountService.Update(model);

            Thread.Sleep(1000);

            return View(model);
        }

        [Authorize(Roles = "User")]
        public IActionResult Contacts()
        {
            AccountVM account = _accountService.GetByName(User.Identity.Name);

            return View(account);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Contacts(AccountVM model)
        {
            _accountService.Update(model);

            Thread.Sleep(1000);

            return View(model);
        }


    }
}