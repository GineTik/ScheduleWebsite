using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ScheduleWebSite.Data;
using ScheduleWebSite.Models;
using ScheduleWebSite.ViewModels;
using System.Security.Claims;

namespace ScheduleWebSite.Controllers
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
            return View(new SignInModel());
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
            return View(new SignUpModel());
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
                    user = new User 
                    { 
                        Name = "New User :^)",
                        Login = model.Login, 
                        PasswordHash = model.Password 
                    };

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
