using Microsoft.EntityFrameworkCore;
using ScheduleWebSite.Application.Interfaces;
using ScheduleWebSite.Domain.Models;

namespace ScheduleWebSite.Data.Contexts
{
    public class ScheduleContext : DbContext, IScheduleContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ScheduleContext(DbContextOptions<ScheduleContext> options)
           : base(options) { }
    }
}
