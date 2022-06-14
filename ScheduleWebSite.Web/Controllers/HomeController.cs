using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleWebSite.Data.Contexts;
using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Web.Controllers
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
            if (Guid.TryParse(HttpContext.User.FindFirst("Id")?.Value, out Guid id))
            {
                User? user = _db.Users.FirstOrDefault(u => u.Id == id);
                ViewBag.User = user;
                return user;
            }
            return null;
        }
    }
}
