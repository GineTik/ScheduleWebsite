using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWebSite.Application.Factories;
using ScheduleWebSite.Data.Contexts;
using ScheduleWebSite.Data.Repositories.Implemention;
using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Web.Controllers
{
    [Authorize]
    public class SchedulesController : Controller
    {
        private ScheduleContext _db;
        private ScheduleRepository _scheduleRepository;
        private DayOfScheduleRepository _dayRepository;

        public SchedulesController(ScheduleContext db)
        {
            _db = db;
            _scheduleRepository = new ScheduleRepository(db);
            _dayRepository = new DayOfScheduleRepository(db);
        }

        public IActionResult Index()
        {
            User user = AuthorizeUser();
            user.Schedules = _scheduleRepository.GetList(user);
            return View(user);
        }

        public IActionResult Item(Guid id)
        {
            User user = AuthorizeUser();
            Schedule? schedule = _db.Schedules
                .Include(s => s.Days).ThenInclude(d => d.Lessons)
                .FirstOrDefault(schedule => schedule.Id == id && schedule.User.Id == user.Id);

            if (schedule == null)
                return NotFound();

            return View(schedule);
        }

        [HttpPost]
        public string AddSchedule()
        {
            User user = AuthorizeUser();
            Schedule schedule = new ScheduleFactory().Create(user);
            _scheduleRepository.AddItem(schedule);
            return schedule.Id.ToString();
        }

        [HttpPost]
        public void DeleteSchedule(Guid id) => _scheduleRepository.DeleteItemAt(id, AuthorizeUser().Id);

        [HttpPost]
        public void ChangeTitle(Guid id, string title) => _scheduleRepository.ChangeTitle(id, title);

        [HttpPost]
        public JsonResult AddDay(Guid scheduleId)
        {  
            DayOfSchedule day = new DayOfScheduleFactory().Create(scheduleId);
            _dayRepository.AddItem(day);
            return Json(day);
        }

        [HttpPost]
        public void DeleteDay(Guid id, Guid scheduleId) => _dayRepository.DeleteItemAt(id, scheduleId);

        [HttpPost] 
        public void ChangeDayTitle(Guid id, Guid scheduleId, string title) => _dayRepository.ChangeTitle(id, scheduleId, title);

        private User? AuthorizeUser()
        {
            Guid id = Guid.Parse(HttpContext.User.FindFirst("Id")?.Value);
            User? user = _db.Users.FirstOrDefault(u => u.Id == id);
            ViewBag.User = user;
            return user;
        }
    }
}
