using ScheduleWebSite.Data.Contexts;
using ScheduleWebSite.Data.Repositories.Interfaces;
using ScheduleWebSite.Domain.Models;
using System.Linq.Expressions;

namespace ScheduleWebSite.Data.Repositories.Implemention
{
    public class DayOfScheduleRepository : BaseRepository<ScheduleContext>, IRepository<DayOfSchedule>
    {
        public DayOfScheduleRepository(ScheduleContext db) : base(db)
        {
        }

        public List<DayOfSchedule> GetList() => _db.DaysOfSchedules.ToList();

        public List<DayOfSchedule> GetList(Expression<Func<DayOfSchedule, bool>> predicate) => _db.DaysOfSchedules.Where(predicate).ToList();

        public DayOfSchedule GetItem(Guid id) => _db.DaysOfSchedules.FirstOrDefault(day => day.Id == id);

        public DayOfSchedule AddItem(DayOfSchedule item)
        {
            _db.DaysOfSchedules.Add(item);
            _db.SaveChanges();
            return item;
        }

        public void UpdateItem(DayOfSchedule item)
        {
            DayOfSchedule day = GetItem(item.Id);
            day = item;
            _db.SaveChanges();
        }

        public void DeleteItem(DayOfSchedule day, Guid scheduleId)
        {
            if (day.ScheduleId != scheduleId)
                throw new ArgumentException("день не знайдено");

            _db.Remove(day);
            _db.SaveChanges();
        }

        public void DeleteItemAt(Guid id, Guid scheduleId)
        {
            var day = GetItem(id);
            DeleteItem(day, scheduleId);
        }

        public void ChangeTitle(Guid id, Guid scheduleId, string name)
        {
            var day = GetItem(id);
            if (day.ScheduleId != scheduleId)
                throw new ArgumentException("день не знайдено");

            day.Name = name;
            _db.SaveChanges();
        }
    }
}
