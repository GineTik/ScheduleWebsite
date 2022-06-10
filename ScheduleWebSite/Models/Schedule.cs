namespace ScheduleWebSite.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
