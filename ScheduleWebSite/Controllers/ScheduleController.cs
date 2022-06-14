using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleWebSite.Data;
using ScheduleWebSite.Models;

namespace ScheduleWebSite.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private ScheduleContext _db;

        public ScheduleController(ScheduleContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(AuthorizeUser());
        }

        [HttpPost]
        public void AddSchedule()
        {

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
