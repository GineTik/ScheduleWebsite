using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleWebSite.Data;
using ScheduleWebSite.Models;

namespace ScheduleWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ScheduleContext _db;

        public HomeController(ScheduleContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            AuthorizeUser();
            return View();
        }

        [Authorize]
        public IActionResult Account()
        {
            return View(AuthorizeUser());
        }

        private User? AuthorizeUser()
        {
            string login = HttpContext.User.FindFirst("Login")?.Value ?? "";
            User? user = _db.Users.FirstOrDefault(u => u.Login == login);
            ViewBag.User = user;
            return user;
        }
    }
}
