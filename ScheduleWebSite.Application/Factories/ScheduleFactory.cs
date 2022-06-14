using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Application.Factories
{
    public class ScheduleFactory
    {
        public Schedule Create(User user)
        {
            return new Schedule() {
                Id = Guid.NewGuid(),
                Title = "Новий розклад",
                User = user,
                TimeOfCreation = DateTime.Now,
            };
        }
    }
}
