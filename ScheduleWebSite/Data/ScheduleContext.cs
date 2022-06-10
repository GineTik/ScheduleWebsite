using Microsoft.EntityFrameworkCore;
using ScheduleWebSite.Models;

namespace ScheduleWebSite.Data
{
    public class ScheduleContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options) { }
    }
}
