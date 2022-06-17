using ScheduleWebSite.Data.Contexts;
using ScheduleWebSite.Data.Repositories.Interfaces;
using ScheduleWebSite.Domain.Models;
using System.Linq.Expressions;

namespace ScheduleWebSite.Data.Repositories.Implemention
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private ScheduleContext _db;

        public ScheduleRepository(ScheduleContext db)
        {
            _db = db;
        }

        public List<Schedule> GetList() => _db.Schedules.ToList();

        public List<Schedule> GetList(Expression<Func<Schedule, bool>> predicate) => _db.Schedules.Where(predicate).ToList();

        public List<Schedule> GetList(User user) => GetList(schedule => schedule.User.Id == user.Id);

        public Schedule GetItem(Guid id) => _db.Schedules.FirstOrDefault(schedule => schedule.Id == id);

        public void UpdateItem(Schedule item)
        {
            Schedule schedule = GetItem(item.Id);
            schedule = item;
            _db.SaveChanges();
        }

        public Schedule AddItem(Schedule item)
        {
            _db.Schedules.Add(item);
            _db.SaveChanges();
            return item;
        }

        public void DeleteItem(Schedule item, Guid userId)
        {
            if (item.User.Id != userId)
                throw new ArgumentException("розклад не знайдено");

            _db.Schedules.Remove(item);
            _db.SaveChanges();
        }

        public void DeleteItemAt(Guid id, Guid userId)
        {
            Schedule schedule = GetItem(id);
            DeleteItem(schedule, userId); 
        }

        public void ChangeTitle(Guid id, string title)
        {
            var schedule = GetItem(id);
            schedule.Title = title;
            _db.SaveChanges();
        }
    }
}
