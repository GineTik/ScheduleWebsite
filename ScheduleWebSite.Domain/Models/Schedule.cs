namespace ScheduleWebSite.Domain.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
