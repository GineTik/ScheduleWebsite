namespace ScheduleWebSite.Domain.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}
