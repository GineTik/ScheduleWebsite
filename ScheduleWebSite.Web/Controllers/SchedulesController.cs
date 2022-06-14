using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleWebSite.Application.Factories;
using ScheduleWebSite.Data.Contexts;
using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Web.Controllers
{
    [Authorize]
    public class SchedulesController : Controller
    {
        private ScheduleContext _db;

        public SchedulesController(ScheduleContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(AuthorizeUser());
        }

        public IActionResult Item(Guid id)
        {
            User user = AuthorizeUser();
            Schedule? schedule = user?.Schedules?.FirstOrDefault(schedule => schedule.Id == id);

            if (schedule == null)
                return NotFound();

            return View(schedule);
        }

        [HttpPost]
        public string AddSchedule()
        {
            User user = AuthorizeUser();
            Schedule schedule = new ScheduleFactory().Create(user);

            Console.WriteLine(user.Id);
            if (schedule == null)
                return null;

            _db.Schedules.Add(schedule);
            _db.SaveChanges();
            return schedule.Id.ToString();
        }

        [HttpPost]
        public void DeleteSchedule(Guid id)
        {
            User user = AuthorizeUser();
            Schedule schedule = user.Schedules.FirstOrDefault(schedule => schedule.Id == id);

            if (schedule == null)
                throw new ArgumentException("Немає розкладу з таким ітендифікатором: " + id);

            _db.Schedules.Remove(schedule);
            _db.SaveChanges();
        }

        [HttpPost]
        public void ChangeTitle(Guid id, string title)
        {
            Schedule schedule = _db.Schedules.FirstOrDefault(schedule => schedule.Id == id);
            schedule.Name = title;
            _db.SaveChanges();
        }

        private User? AuthorizeUser()
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id")?.Value);
            User? user = _db.Users.FirstOrDefault(u => u.Id == id);
            _db.Entry(user).Collection(c => c.Schedules).Load();
            ViewBag.User = user;
            return user;
        }
    }
}
