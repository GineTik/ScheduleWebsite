using Microsoft.EntityFrameworkCore;
using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Application.Interfaces
{
    public interface IScheduleContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
