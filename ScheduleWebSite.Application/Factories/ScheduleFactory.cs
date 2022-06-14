using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Application.Factories
{
    public class ScheduleFactory
    {
        public Schedule Create(User user)
        {
            return new Schedule() {
                Id = Guid.NewGuid(),
                Name = "Новий розклад",
                User = user
            };
        }
    }
}
