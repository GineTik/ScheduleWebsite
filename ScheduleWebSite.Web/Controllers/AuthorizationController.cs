using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ScheduleWebSite.Data.Contexts;
using ScheduleWebSite.Web.ViewModels;
using ScheduleWebSite.Domain.Models;
using ScheduleWebSite.Application.Factories;

namespace ScheduleWebSite.Web.Controllers
{
    public enum AuthorizationStatus
    {
        UserFinded = 0,
        UserNotFound = 1
    }

    public class AuthorizationController : Controller
    {
        private ScheduleContext _db;

        public AuthorizationController(ScheduleContext db)
        {
            _db = db;
        }

        public IActionResult SignIn()
        {
            if (User?.Identity?.IsAuthenticated == false)
            {
                return View(new SignInModel());
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                User? user = _db.Users.FirstOrDefault(u => u.Login == model.Login && u.PasswordHash == model.Password);

                if (user != null)
                {
                    await Authenticate(user); // аутентификация
                    return RedirectToAction("Account", "Home");
                }
                ModelState.AddModelError("", "Некоректні логін і(або) пароль");
            }
            return View(model);
        }

        public IActionResult SignUp()
        {
            if (User?.Identity?.IsAuthenticated == false)
            {
                return View(new SignUpModel());
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                User? user = _db.Users.FirstOrDefault(u => u.Login == model.Login && u.PasswordHash == model.Password);
                if (user == null)
                {
                    user = new UserFactory().Create(model.Login, model.Password);

                    _db.Users.Add(user);
                    _db.SaveChanges();

                    await Authenticate(user); // аутентификация
                    return RedirectToAction("Account", "Home");
                }
                ModelState.AddModelError("", "Користувач з таким логіном вже існує");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Login", user.Login),
                new Claim("Password", user.PasswordHash)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
